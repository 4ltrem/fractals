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
    // Mandelbrot
    //----------------------------------------------------------------------------
    public class Mandelbrot : Fractal
    {
        //------------------------------------------------------------------------
        // Constructeur paramétré
        //------------------------------------------------------------------------
        public Mandelbrot(int dimensions) : base(dimensions) { }

        //------------------------------------------------------------------------
        // Fonction déterminant la couleur du pixel (rangée,colonne) de fractal
        // Mandelbrot d'une densité donnée (delta).
        //------------------------------------------------------------------------
        public override Color calculerCouleurPixel(int rangée, int colonne)
        {
            /*** Basé sur la fonction de Julia et le powerpoint ***/

            Complexe c = new Complexe(Xm + colonne * Delta, Ym + rangée * Delta);
            Complexe z = new Complexe(0, 0);

            int itérations = 0;
            do
            {
                z = (z * z) + c;
                itérations++;
            } while (z.Module < 2 && itérations < Itérations);

            couleurs[rangée, colonne] = itérations;
            Color couleur = couleurs[rangée, colonne] < Itérations ? Palette[(int)PaletteCourante, couleurs[rangée, colonne] % 256] : Color.Black;

            return couleur;
        }
    }
}
