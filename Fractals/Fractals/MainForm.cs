using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class MainForm : Form
    {
        //------------------------------------------------------------------------
        // Catégories de fractals pouvant être construites
        //------------------------------------------------------------------------
        public enum CatégorieFractal { Mandelbrot, Julia }

        //------------------------------------------------------------------------
        // Thread construisant l'image du fractal dans offScreenBmpEnConstruction
        //------------------------------------------------------------------------
        private BackgroundWorker tâche = null;

        //------------------------------------------------------------------------
        // Instance de fractal dont fut construit l'image affichée
        //------------------------------------------------------------------------
        Fractal fractal = null;

        //------------------------------------------------------------------------
        // Taille de l'image du fractal. Correspond à la taille du canevas 
        // d'affichage (canevasPanel)
        //------------------------------------------------------------------------
        private int Dimensions
        {
            get { return canevasPanel.Width; }
        }

        //------------------------------------------------------------------------
        // Facteur de zoom actuel, selon le setting du contrôle permettant de 
        // l'ajuster
        //------------------------------------------------------------------------
        private int FacteurZoom
        {
            get { return (int)zoomUpDown.Value; }
        }

        //------------------------------------------------------------------------
        // Nombre maximum d'itérations, selon le setting du contrôle permettant de 
        // l'ajuster
        //------------------------------------------------------------------------
        private int Itérations
        {
            get { return (int)itérationsUpDown.Value; }
        }

        //------------------------------------------------------------------------
        // Palette de couleurs à appliquer au prochain fractal, selon le setting 
        // du contrôle permettant de  la sélectionner
        //------------------------------------------------------------------------
        private Fractal.TypePalette PaletteCourante
        {
            get { return (Fractal.TypePalette)paletteComboBox.SelectedIndex; }
        }

        //------------------------------------------------------------------------
        // Bitmap contenant les fractals
        //------------------------------------------------------------------------
        private Bitmap imageFractal;                        // image du fractal affichée dans le canevas
        private Bitmap imageFractalEnConstruction;          // image du fractal en cours de construction

        //------------------------------------------------------------------------
        // Indique si le curseur doit être remplacé par un rectangle indiquant le facteur de zoom
        // dans le canevas
        //------------------------------------------------------------------------
        private Boolean DoitActiverCurseurZoom
        {
            get
            {
                Point p = canevasPanel.PointToClient(Cursor.Position);
                Rectangle rect = new Rectangle(0, 0, canevasPanel.Width, canevasPanel.Height);

                return (imageFractal != null) && rect.Contains(p);
            }
        }

        //------------------------------------------------------------------------
        // Retourve le rectangle correspondant la zone qui sera affichée dans le 
        // canevas selon le facteur de zoom
        //------------------------------------------------------------------------
        private Rectangle RectangleDeCurseurZoom
        {
            get
            {
                Point p = canevasPanel.PointToClient(Cursor.Position);

                int w = this.Dimensions / FacteurZoom;
                Rectangle rect = new Rectangle(p.X - w / 2, p.Y - w / 2, w, w);

                return rect;
            }
        }

        //------------------------------------------------------------------------
        // Constructeur par défaut
        //------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            // Catégorie de fractal par défaut
            paletteComboBox.SelectedIndex = 0;
        }

        //------------------------------------------------------------------------
        // Fonction démarrant la tâche de construction de fractal selon les
        // paramètres par défaut
        //------------------------------------------------------------------------
        private void initierTâcheConstructionFractal(CatégorieFractal catégorie)
        {
            // On instancie un fractal 
            if (catégorie == CatégorieFractal.Julia)
                fractal = new Julia(Dimensions);
            else
                fractal = new Mandelbrot(Dimensions);

            fractal.Itérations = Itérations;
            fractal.PaletteCourante = PaletteCourante;

            démarrerTâcheConstructionFractal();
        }

        //------------------------------------------------------------------------
        // Fonction créant, configurant et démarrant la tâche de construction du
        // fractal
        //------------------------------------------------------------------------
        private void démarrerTâcheConstructionFractal()
        {
            // S'assurer que l'utilisateur ne peut pas démaarrer la construction
            // d'un second fractal avant que celui-ci ne soit terminée
            goMandelbrotButton.Enabled = false;
            goJuliaButton.Enabled = false;

            // Activer le bouton permettant d'interrompre le tâche
            stopButton.Visible = true;

            // Créer une tâche d'arrière-plan qui s'occupera de construire le
            // fractal. Le fait d'utiliser une telle tâche permet de ne pas
            // bloquer la tâche du UI durant la construction, évitant ainsi de
            // bloquer l'application
            tâche = new BackgroundWorker();

            tâche.DoWork += tâcheConstructionFractal;
            tâche.ProgressChanged += tâcheRafraîchirProgrès;
            tâche.RunWorkerCompleted += tâcheComplétée;  //Tell the user how the process went
            tâche.WorkerReportsProgress = true;
            tâche.WorkerSupportsCancellation = true; //Allow for the process to be cancelled

            // Configurer et afficher la barre de progression
            progressBar.Maximum = Dimensions - 1;
            progressBar.Visible = true;

            // Et on démarre la tâche de construction du fractal
            tâche.RunWorkerAsync();
        }

        //------------------------------------------------------------------------
        // Fonction exécutée en arrière-plan pour construire le fractal
        //------------------------------------------------------------------------
        private void tâcheConstructionFractal(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // On démarre la construction, alors on l'indique
            tâche.ReportProgress(0);

            // Définir la bitmap où sera dessinée le fractal en arrière-plan. Notez qu'on
            // utilise un bitmap distinct de celui d'affichage car ce dernier est affiché
            // dans la forme, ce qui peut occasionner un conflit fatal entre la tâche
            // d'arrière-plan et celle du UI
            imageFractalEnConstruction = new Bitmap(Dimensions, Dimensions, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Calculer la densité d'échantillonnage du fractal selon le nombre
            // de pixels affichés
            double delta = fractal.Largeur / (Dimensions - 1);

            // Construction du fractal, on point à la fois
            for (int r = 0; r < Dimensions; r++)
            {
                for (int c = 0; c < Dimensions; c++)
                {
                        imageFractalEnConstruction.SetPixel(c, r, fractal.calculerCouleurPixel(r, c));
                }

                // Check if there is a request to cancel the process
                if (tâche.CancellationPending)
                {
                    e.Cancel = true;

                    return;
                }
                else
                {
                    tâche.ReportProgress(r);
                }
            }
        }

        //------------------------------------------------------------------------
        // Fonction invoquée périodiquement par la tâche d'arrière-plan pour
        // mettre à jour la barre de progression indiquant le % complété de la
        // construction
        //------------------------------------------------------------------------
        private void tâcheRafraîchirProgrès(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        //------------------------------------------------------------------------
        // Fonction invoquée automatiquement lorsque la tâche d'arrière-plan de
        // construction de fractal est terminée
        //------------------------------------------------------------------------
        private void tâcheComplétée(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // S'assurer que la construction du fractal fut complétée
            if (e.Error != null)
            {
                MessageBox.Show("Une erreur s'est produite durant la génération du fractal", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!e.Cancelled)
            {
                // Transférer les pixels du fractal dans le bitmap qui sera ensuite
                // affiché
                Color couleur;
                for (int r = 0; r < Dimensions; r++)
                {
                    for (int c = 0; c < Dimensions; c++)
                    {
                        couleur = fractal[r, c] < fractal.Itérations ? fractal.Palette[(int)fractal.PaletteCourante, fractal[r, c] % 256] : Color.Black;

                        imageFractalEnConstruction.SetPixel(c, r, couleur);
                    }
                }

                // Le bitmap construit transféré dans la variable d'affichage
                imageFractal = imageFractalEnConstruction;

                // Forcer le réaffichage du bitmap à l'écran
                canevasPanel.Invalidate();
            }

            // Mettre à jour l'accès aux éléments d'interface permettant le démarrer
            // la constructIon d'un nouveau fractal
            stopButton.Visible = false;
            progressBar.Visible = false;

            goMandelbrotButton.Enabled = true;
            goJuliaButton.Enabled = true;

            // Mettre ces paramètres à null car on les utilise pour savoir si un
            // fractal est en construction
            tâche = null;
            imageFractalEnConstruction = null;
        }

        //------------------------------------------------------------------------
        // Fonction convertissant les coordonnées d'un pixel d'écran en 
        // coordonnées du point de fractal correspondant
        //------------------------------------------------------------------------
        private void enFractal(int pixelX, int pixelY, out double fractalX, out double fractalY)
        {
            fractalX = fractal.Xm + (1.0 * pixelX / Dimensions) * fractal.Largeur;
            fractalY = fractal.Ym + (1.0 * pixelY / Dimensions) * fractal.Largeur;
        }

        //------------------------------------------------------------------------
        // Rafraîchit le panel d'affichage de fractal de la forme: on y affiche
        // l'image du fractal ainsi que le rectangle de zoom
        //------------------------------------------------------------------------
        private void dessinerCanvas()
        {
            // Afficher la bitmap et le rectangle dans le panel
            using (Graphics g = canevasPanel.CreateGraphics())
            using (Pen crayon = new Pen(Color.White))
            {
                if (imageFractal != null)
                {
                    // Afficher le bitmap
                    g.DrawImage(imageFractal, 0, 0);

                    // Afficher le rectangle de zoom au curseur s'il le faut
                    if (DoitActiverCurseurZoom)
                    {
                        crayon.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawRectangle(crayon, RectangleDeCurseurZoom);
                    }
                }
            }
        }

        //------------------------------------------------------------------------
        // Gestion du click du bouton de construction de fractal Mandelbrot
        //------------------------------------------------------------------------
        private void goMandelBrotButton_Click(object sender, EventArgs e)
        {
            initierTâcheConstructionFractal(CatégorieFractal.Mandelbrot);
        }

        //------------------------------------------------------------------------
        // Gestion du click du bouton d'annulation de construction de fractal.
        // On interrompt la tâche d'arrière-plan
        //------------------------------------------------------------------------
        private void stopButton_Click(object sender, EventArgs e)
        {
            if (tâche != null && tâche.IsBusy)
                tâche.CancelAsync();
        }

        //------------------------------------------------------------------------
        // Gestion du click du bouton de construction de fractal Julia
        //------------------------------------------------------------------------
        private void goJuliaButton_Click(object sender, EventArgs e)
        {
            initierTâcheConstructionFractal(CatégorieFractal.Julia);
        }

        //------------------------------------------------------------------------
        // Gère la sélection d'une zone de zoom dans le canevas : on doit
        // modifier les abcisses u fractal et initier sa reconstruction.
        //------------------------------------------------------------------------
        private void canvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (tâche == null && fractal != null)
            {
                double x, y;
                enFractal(e.X, e.Y, out x, out y);

                fractal.Largeur /= FacteurZoom;

                fractal.Xm = x - fractal.Largeur / 2;
                fractal.Ym = y - fractal.Largeur / 2;

                fractal.Itérations = Itérations;
                fractal.PaletteCourante = PaletteCourante;

                démarrerTâcheConstructionFractal();
            }
        }

        //------------------------------------------------------------------------
        // On doit rafraîchir le canevas afin d'afficher le rectangle de zoom
        // affiché au curseur
        //------------------------------------------------------------------------
        private void canvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            dessinerCanvas();
        }

        //------------------------------------------------------------------------
        // On doit rafraîchir le canevas afin d'effacer le rectangle de zoom
        // affiché au curseur
        //------------------------------------------------------------------------
        private void canvasPanel_MouseLeave(object sender, EventArgs e)
        {
            dessinerCanvas();
        }

        //------------------------------------------------------------------------
        // Affiche le canevas à l'écran
        //------------------------------------------------------------------------
        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
            dessinerCanvas();
        }
    }
}
