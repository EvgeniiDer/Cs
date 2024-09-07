
using System.Globalization;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Net8{
    class Fraction{
        private int integer;
        private int numerator;
        private int denominator;
        public int Integer{
            get{
                return integer;
            }
            set{
                integer = value;
            }
        }
        public int Numerator{
            get => numerator;
            set{
                numerator = value;
            }
        }
        public int Denominator{
            get => denominator;
            set{
                if(value == 0)
                {
                    value = 1;
                }
                denominator = value;
            }
        }
        public Fraction(){
           denominator = 1;
        }
        public Fraction(int _integer)
        {
            this.integer = _integer;
            this.denominator = 1;
        }
        public Fraction(int _numerarot, int _denominator)
        {
            this.numerator = _numerarot;
            this.denominator = _denominator;
        }
        public Fraction(int _integer , int _numerarot , int _denominator ){
            this.integer = _integer;
            this.numerator = _numerarot;
            this.denominator = _denominator;
        }
        public Fraction(Fraction _arg){
            this.integer = _arg.integer;
            this.numerator = _arg.numerator;
            this.denominator = _arg.denominator;
        }
        public Fraction(double _number)
        {
             _number += 1e-10 - 0.0000000001;
            integer = (int)_number;
            denominator = 1000000000;
            numerator = (int)((_number - (double)integer) * (double)denominator);
            reduce();
        } 
        private Fraction ToProper()
        {
            this.integer += this.Numerator / this.Denominator;
			this.Numerator = this.Numerator % this.Denominator;
            return this;
        }
        private Fraction ToImproper()
        {
            this.numerator += this.integer * this.denominator;
            integer = 0;
            return this;
        }
        private Fraction Inverted()
        {
            (this.Numerator, this.Denominator) = (this.Denominator, this.Numerator);
            return this;
        }
        private Fraction reduce()
        {
            int more, less, rest;
            if(numerator > denominator)
            {
                more  = numerator;
                less = denominator;
            }
            else{
                less = numerator;
                more = denominator;
            }
            do{
                rest = more % less;
                more = less;
                less = rest;
            }while(rest > 0);
             int GCD  = more;
             numerator /= GCD;
             denominator /= GCD;
             return this;
        }
        static public Fraction operator*(Fraction _argLeft, Fraction _argRight)
        {
            return new Fraction(_argLeft.ToImproper().numerator * _argRight.ToImproper().numerator,
                                _argLeft.ToImproper().denominator * _argRight.ToImproper().denominator).ToProper().reduce();
        }
        static public Fraction operator/(Fraction _argLeft, Fraction _argRight)
        {
            return _argLeft * _argRight.Inverted();
        }
        public static bool operator==(Fraction _argLeft, Fraction _argRight)
        {
            return _argLeft.ToImproper().numerator * _argRight.ToImproper().denominator == _argLeft.ToImproper().denominator * _argRight.ToImproper().numerator;
        }
        public static bool operator!=(Fraction _argLeft, Fraction _argRight)
        {
            return !(_argLeft == _argRight);
        }
        public static Fraction operator+(Fraction _argLeft, Fraction _argRight)
        {
            int buffDen = _argLeft.denominator * _argRight.denominator;
            return new Fraction(
                _argLeft.ToImproper().numerator * _argRight.ToImproper().denominator +
                _argLeft.ToImproper().denominator * _argRight.ToImproper().numerator,
                buffDen
                ).ToProper();
                //
        }
        public static Fraction operator-(Fraction _argLeft, Fraction _argRight)
        {
            return new Fraction(
                _argLeft.ToImproper().numerator * _argRight.ToImproper().denominator - 
                _argLeft.ToImproper().denominator * _argRight.ToImproper().numerator,
                _argLeft.denominator * _argRight.denominator
            ).ToProper();
        }
        public static Fraction operator++(Fraction _arg){
            _arg.integer = ++_arg.integer;
            return _arg;
        }
        public static Fraction operator--(Fraction _arg)
        {
            _arg.integer = --_arg.integer;
            return _arg;
        }
        //public static Fraction operator-=(Fraction _arg) Operatori prisvaivaniy ne v c# ne mogut bit perezagrujens 
        public static bool operator>(Fraction _argLeft, Fraction _argRight)
        =>_argLeft.ToImproper().numerator * _argRight.ToImproper().denominator >
          _argLeft.ToImproper().denominator * _argRight.ToImproper().numerator;
        public static bool operator <(Fraction _argLeft, Fraction _argRight)
        =>_argLeft.ToImproper().numerator * _argRight.ToImproper().denominator <
          _argLeft.ToImproper().denominator * _argRight.ToImproper().numerator;
        public static bool operator <=(Fraction _argLeft, Fraction _argRight)
        =>!(_argLeft > _argRight);
        public static bool operator >=(Fraction _argLeft, Fraction _argRight)
        =>!(_argLeft < _argRight);
        public void Print()
        {
            if(this.integer > 0){
                Console.Write(this.integer);
            }
            if(this.numerator > 0)
                {
                    if(this.integer > 0)
                        {
                            Console.Write("(");
                        }
                    Console.Write($"{this.numerator} / {this.denominator}");
                    if(this.integer > 0)
                        {
                            Console.Write(")");
                        }
                    else if(this.integer  == 0)
                        {
                             Console.WriteLine(' ');   
                        }
                }
        }
    }
}