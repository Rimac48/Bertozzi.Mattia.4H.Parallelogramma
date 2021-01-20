using System;

namespace Bertozzi.Mattia._4H.Parallelogramma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma ^Parallelogramma^ Mattia Bertozzi 4H");
            //Console.WriteLine("Riconosco se è anche rombo o quadrato!\n");

            Parallelogramma P = new Parallelogramma();

            Console.WriteLine($"Lato Maggiore=\t{P.CalcolaLatoMaggiore(P)}\n");
            Console.WriteLine($"Lato Minore=\t{P.CalcolaLatoMinore(P)}\n");
            Console.WriteLine($"Perimetro=\t{P.CalcolaPerimetro(P)}\n");
            Console.WriteLine($"Area=\t{P.CalcolaArea(P)}\n");

        }
    }

    class Parallelogramma
    {
        private double _dmaggiore;
        private double _dminore;
        private double _angolodmaggiore;

        public Parallelogramma(double dmag,double dmin,double angolo)
        {
            _dmaggiore = dmag;
            _dminore = dmin;
            _angolodmaggiore = angolo;
        }

        public Parallelogramma()
        {
            _dmaggiore = 160;
            _dminore = 74;
            _angolodmaggiore = 20;
        }

        public double DMaggiore
        {
            get
            {
                return _dmaggiore;
            }
            set
            {
                _dmaggiore = value;
            }
        }

        public double DMinore
        {
            get
            {
                return _dminore;
            }
            set
            {
                _dminore = value;
            }
        }

        public double angoloDMaggiore
        {
            get
            {
                return _angolodmaggiore;
            }
            set
            {
                _angolodmaggiore = value;
            }
        }

        //MEDOTI 

        public double CalcolaLatoMaggiore(Parallelogramma p)
        {
            double dmag = p.DMaggiore;
            double dmin = p.DMinore;
            double angolo = p.angoloDMaggiore;

            //se Quadrato
            if(dmag==dmin)
            {
                double lato = dmag / Math.Sqrt(2);
                return lato;
            }

            //se rombo
            else if(dmin==(dmag/2))
            {
                double lato = Math.Sqrt(Math.Pow((dmag / 2), 2) - Math.Pow((dmin / 2), 2));
            }

            //altrimenti se parallelogramma standard
            else if (dmag != dmin)
            {
                //SISTEMARE CALCOLO
                //IL SIN DA UN NUMERO IN RADIANTI,TROVA IL MODO DI CONVERTIRE IN GRADI 
                double tmp = angolo * Math.PI / 180;
                //altezza
                double h = dmag * tmp;

                //segmento maggiore lato maggiore
                double segmax = Math.Sqrt(Math.Pow((dmag / 2), 2) - Math.Pow((h / 2), 2));

                //altro angolo che serve per calcolo
                double angolo2 = Math.Asin((h / dmin));

                //segmento minore lato maggiore
                double segmin = (dmin / 2) * Math.Cos(angolo2);

                //lato maggiore
                double latoMaggiore = segmax + segmin;

                return latoMaggiore;
            }

            return 0;
        }

        public double CalcolaLatoMinore(Parallelogramma p)
        {
            double latoMaggiore = CalcolaLatoMaggiore(p);

            double dmag = p.DMaggiore;
            double dmin = p.DMinore;
            double angolo = p.angoloDMaggiore;

            //se quadrato
            if (dmag == dmin)
            {
                double lato = dmag / Math.Sqrt(2);
                return lato;
            }

            //se rombo
            else if (dmin == (dmag / 2))
            {
                double lato = Math.Sqrt(Math.Pow((dmag / 2), 2) - Math.Pow((dmin / 2), 2));
            }

            //altrimenti se parallelogramma standard
            else if (dmag != dmin)
            {
                //altezza
                double h = dmag * Math.Sin(angolo);

                //segmento maggiore lato maggiore
                double segmax = Math.Sqrt(Math.Pow((dmag / 2), 2) - Math.Pow((h / 2), 2));

                //altro angolo che serve per calcolo
                double angolo2 = Math.Asin((h / dmin));

                //teorema di Carnot
                double latoMinore = Math.Sqrt((Math.Pow(latoMaggiore, 2)) + (Math.Pow(dmin, 2)) - (2 * dmin * latoMaggiore * Math.Cos(angolo2)));

                return latoMinore;
            }

            return 0;

        }

        public double CalcolaPerimetro(Parallelogramma p)
        {
            double latoMaggiore = CalcolaLatoMaggiore(p);
            double latoMinore = CalcolaLatoMinore(p);

            double dmag = p.DMaggiore;
            double dmin = p.DMinore;

            //se quadrato
            if (dmag == dmin)
            {
                double Perimetro = latoMaggiore * 4;
                return Perimetro;
            }

            //se rombo
            else if (dmin == (dmag / 2))
            {
                double Perimetro = latoMaggiore * 4;
                return Perimetro;

            }

            //altrimenti se parallelogramma standard
            else if (dmag != dmin)
            {
                double Perimetro = (latoMaggiore * 2) + (latoMinore * 2);
                return Perimetro;
            }
            return 0;
        }
        public double CalcolaArea(Parallelogramma p)
        {
            double dmin = p.DMinore;
            double dmag = p.DMaggiore;
            double angolo = p.angoloDMaggiore;

            //se quadrato
            if (dmag == dmin)
            {
                double lato = CalcolaLatoMaggiore(p);
                double Area = lato * lato;
                return Area;
            }

            //se rombo
            else if (dmin == (dmag / 2))
            {
                double Area = (dmag * dmin) / 2;

            }

            //altrimenti se parallelogramma standard
            else if (dmag != dmin)
            {
                //altezza
                double h = dmag * Math.Sin(angolo);
                //base
                double b = CalcolaLatoMaggiore(p);

                double Area = b * h;

                return Area;
            }
            return 0;

        }
    }
}
