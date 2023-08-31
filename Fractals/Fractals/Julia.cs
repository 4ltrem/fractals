using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractals
{
    //----------------------------------------------------------------------------
    // Classe implantant les attributs permettant de produire des fractals de
    // Julia
    //----------------------------------------------------------------------------
    public class Julia : Fractal
    {
        //------------------------------------------------------------------------
        // Valeur minimum de l'abcisse en X pour produire des Julia
        //------------------------------------------------------------------------
        private double xj = -0.0519;
        public double Xj
        {
            get { return xj; }
            set { xj = value; }
        }

        //------------------------------------------------------------------------
        // Valeur minimum de l'abcisse en Y pour produire des Julia
        //------------------------------------------------------------------------
        private double yj = 0.688;
        public double Yj
        {
            get { return yj; }
            set { yj = value; }
        }

        //------------------------------------------------------------------------
        // Constructeur paramétré
        //------------------------------------------------------------------------
        public Julia(int dimensions) : base(dimensions) { }

        //------------------------------------------------------------------------
        // Fonction déterminant la couleur du pixel (rangée,colonne) de fractal
        // Julia d'une densité donnée (delta).
        //------------------------------------------------------------------------
        public override Color calculerCouleurPixel(int rangée, int colonne)
        {
            Complexe c = new Complexe(Xm + colonne * Delta, Ym + rangée * Delta);
            Complexe z = new Complexe(Xj, Yj);

            int itérations = 0;
            do
            {
                c = (c * c) + z;
                itérations++;
            //  Petite modification ici pour ressembler le powerpoint, donne le même  résultats
            } while (Math.Pow(c.Module, 2) < 4 && itérations < Itérations);

            couleurs[rangée, colonne] = itérations;
            Color couleur = couleurs[rangée, colonne] < Itérations ? Palette[(int)PaletteCourante, couleurs[rangée, colonne] % 256] : Color.Black;

            return couleur;
        }
    }
}
