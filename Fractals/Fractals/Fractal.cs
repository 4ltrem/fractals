  using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractals
{
    //----------------------------------------------------------------------------
    // Classe de base abstraite facilitant la gestion des attributs permettant de
    // produire des fractals de Mandelbrot et Julia
    //----------------------------------------------------------------------------
    abstract public class Fractal
    {
        //------------------------------------------------------------------------
        // Définition des palettes de couleurs disponibles pour produire les 
        // fractals
        //------------------------------------------------------------------------
        public enum TypePalette { Aléatoire = 0, Binaire, Modulée }

        //------------------------------------------------------------------------
        // Valeur minimum de l'abcisse en X pour produire des fractals
        //------------------------------------------------------------------------
        private double xm = -1.5;
        public double Xm
        {
            get { return xm; }
            set { xm = value; }
        }

        //------------------------------------------------------------------------
        // Valeur minimum de l'abcisse en Y pour produire des fractals
        //------------------------------------------------------------------------
        private double ym = -1.5;
        public double Ym
        {
            get { return ym; }
            set { ym = value; }
        }

        //------------------------------------------------------------------------
        // Étendue des abcisses en X et Y des fractals
        //------------------------------------------------------------------------
        private double largeur = 3.0;
        public double Largeur
        {
            get { return largeur; }
            set { largeur = value; }
        }

        //------------------------------------------------------------------------
        // Nombre d'itérations à appliquer pour calculer chaque pixel du
        // fractal
        //------------------------------------------------------------------------
        private int itérations = 50;
        public int Itérations
        {
            get { return itérations; }
            set { itérations = value; }
        }

        //------------------------------------------------------------------------
        // Palette de couleur servant à construire et afficher le fractal
        //------------------------------------------------------------------------
        private Color[,] palette = new Color[Enum.GetNames(typeof(TypePalette)).Length, 256];
        public Color[,] Palette
        {
            get { return palette; }
            set { palette = value; }
        }

        //------------------------------------------------------------------------
        // Type de palette du fractal
        //------------------------------------------------------------------------
        private TypePalette paletteCourante = TypePalette.Aléatoire;  // 0=Aléatoire, 1=Binaire, 2=Modulée
        public TypePalette PaletteCourante
        {
            get { return paletteCourante; }
            set { paletteCourante = value; }
        }

        //------------------------------------------------------------------------
        // Matrice d'itérations fractales pour chaque point de mesure
        //------------------------------------------------------------------------
        protected int[,] couleurs = null;

        // Indexer declaration
        public int this[int r, int c]
        {
            get { return couleurs[r, c]; }
        }

        //------------------------------------------------------------------------
        // Taille de l'image du fractal. Correspond généralement à la taille du  
        // canevas d'affichage
        //------------------------------------------------------------------------
        public int Dimensions
        {
            get { return couleurs.GetLength(0); }
            set { couleurs = new int[value, value]; }
        }

        //------------------------------------------------------------------------
        // Retourne la densité d'échantillonnage du fractal selon le nombre
        // de pixels affichés
        //------------------------------------------------------------------------
        protected double Delta
        {
            get { return Largeur / (Dimensions - 1); }
        }

        //------------------------------------------------------------------------
        // Constructeur paramétré
        //------------------------------------------------------------------------
        public Fractal(int dimensions) 
	    {
            Dimensions = dimensions;

            Random random = new Random();

		    // On attribue la couleur noire à la dernière couleur de chacune des trois palettes
            palette[(int)TypePalette.Aléatoire, 255] = palette[(int)TypePalette.Binaire, 255] = palette[(int)TypePalette.Modulée, 255] = Color.Black;
		
		    // On génère les couleurs de la palette aléatoire et de la palette binaire
		    for (int i = 0; i < 256; i++) {
                palette[(int)TypePalette.Aléatoire, i] = Color.FromArgb((int)(random.NextDouble() * 16777216));
                palette[(int)TypePalette.Binaire, i] = (i % 2 == 0 ? Color.Blue : Color.Yellow);
		    }
		
		    // On génère les couleurs de la palette modulée
		    int r = (int) (random.NextDouble() * 256);
		    int v = (int) (random.NextDouble() * 256);
		    int b = (int) (random.NextDouble() * 256);

		    int dr = (random.NextDouble() < 0.5 ? 1 : -1);
		    int dv = (random.NextDouble() < 0.5 ? 1 : -1);
		    int db = (random.NextDouble() < 0.5 ? 1 : -1);

		    for (int i = 0; i < 256; i++) {
                palette[(int)TypePalette.Modulée, i] = Color.FromArgb(r, v, b);

			    r += dr;
			    if (r == -1 || r == 256) {
				    dr *= -1;
				    r = (r == -1 ? 1 : 254);
			    }

			    v += dv;
			    if (v == -1 || v == 256) {
				    dv *= -1;
				    v = (v == -1 ? 1 : 254);
			    }

			    b += db;
			    if (b == -1 || b == 256) {
				    db *= -1;
				    b = (b == -1 ? 1 : 254);
			    }
		    }	
	    }

        //------------------------------------------------------------------------
        // Fonction déterminant la couleur du pixel (rangée,colonne) de fractal
        // Julia d'une densité donnée (delta).
        //------------------------------------------------------------------------
        abstract public Color calculerCouleurPixel(int rangée, int colonne);
    }
}
