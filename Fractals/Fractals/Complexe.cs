using System;

namespace Fractals
{
    //----------------------------------------------------------------------------
    // Classe représentant des nombres complexes de la forme a + bi, avec les
    // opérateurs arithmétiques de base.
    //----------------------------------------------------------------------------
    public class Complexe
    {

        // Variables
        private double a = 0.0; // partie réelle
        private double b = 0.0;	// partie imaginaire
        public double Module = 0.0;

        //------------------------------------------------------------------------
        //Constructeur par défaut: crée le nombre a+bi
        //------------------------------------------------------------------------
        public Complexe(double a = 0.0, double b = 0.0)
        //------------------------------------------------------------------------
        {
            this.a = a;
            this.b = b;

            // Affectation de la variable Module avec l'equation utilisant a et b
            this.Module = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        /*** SURCHARGE DES OPÉRATEURS * ET + ***/
        public static Complexe operator *(Complexe u, Complexe v) => new Complexe((u.a * v.a) - (u.b * v.b), (u.a * v.b + u.b * v.a) );
        public static Complexe operator +(Complexe u, Complexe v) => new Complexe(u.a + v.a, (u.b + v.b) );
    }
}
