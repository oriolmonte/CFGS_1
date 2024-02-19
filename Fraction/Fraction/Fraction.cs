using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fraction
{
    internal class Fraction
    {
        private int a_num;
        private int a_den;
        private char a_sign;

        #region Constructors
        public Fraction(int num, int den, char sign)
        {
            if (den == 0 || den == null) throw new Exception("Cannot divide by zero");
            if (num < 0) throw new Exception("Numerator cannot be negative");
            if ((char)sign != '+' && (char)sign != '-') throw new Exception("Sign can only be '+' or '-'");
            this.a_num = num;
            this.a_den = den; 
            this.a_sign = sign;
        }
        public Fraction(Fraction f)
        :this(f.a_num, f.a_den, f.a_sign){
        }
        public Fraction()
        :this(0,1,'-'){
        }
        #endregion
        #region Propietats
        public int Numerator
        {
            get
            {
                return a_num;
            }
            set
            {
                if (value < 0) throw new Exception("Numerator cannot be negative");
                a_num = value;
            }
        }
        public int Denominator
        {
            get { return a_den; }
            set
            {
                if (value == 0 || value == null) throw new Exception("Cannot divide by zero");
                a_den = value;
            }
        }
        public char Sign
        {
            get { return a_sign; }
            set
            {
                if (value != '+' || value != '-') throw new Exception("Sign can only be '+' or '-'");
                a_sign = value;

            }
        }
        public double RealValue
        {
            get
            {
                if (a_sign == '-')
                    return (double) - a_num / a_den;
                else
                    return (double) a_num / a_den;
            }
        }
        #endregion
        #region Privats
        private int MCD(int a, int b)
        {
            int small, big, remainder;
            if (a > b)
            {
                small = b;
                big = a;
            }
            else
            {
                small = a;
                big = b;
            }
            if (small != 0)
            {
                remainder = big % small;
                while (remainder > 0)
                {
                    remainder = big % small;
                    if (remainder != 0)
                    {
                        big = small;
                        small = remainder;
                    }
                }
                if (a == b)
                    small = a;
            }
            else
            {
                small = 1;
            }
            return small;
        }
        #endregion
        #region Instancia
        public void Simplify()
        {
            int mcd = MCD(this.a_num, this.a_den);
            this.a_num = this.a_num / mcd;
            this.a_den = this.a_den / mcd;
        }
        public void Multiply(Fraction f)
        {
            this.a_num = a_num * f.a_num;
            this.a_den = a_den * f.a_den;
            Simplify();
            if (a_sign == f.a_sign)
                a_sign = '+';
            else
                a_sign = '-';

        }
        public void Divide(Fraction f)
        {
            this.a_num *= f.a_den;
            this.a_den *= f.a_num;
            Simplify();
            if (a_sign == f.a_sign)
                a_sign = '+';
            else
                a_sign = '-';
        }
        public void Sum(Fraction f)
        {
            int tmpA_num = a_num;
            int tmpParamA_num = f.a_num;
            tmpA_num = this.a_num * f.a_den;
            tmpParamA_num = f.a_num * this.a_den;
            this.a_den = this.a_den * f.a_den;
            if(a_sign == '-')
                tmpA_num = -tmpA_num;
            if (f.a_sign == '-')
                tmpParamA_num = -tmpParamA_num;
            tmpA_num = tmpA_num+tmpParamA_num;
            if (tmpA_num > 0)
            {
                a_num = tmpA_num;
                a_sign = '+';
            }
            //ZERO IS ASSUMED NEGATIVE
            if (tmpA_num <= 0)
            {
                a_num = -tmpA_num;
                a_sign = '-';
            }
            Simplify();            
        }

        #endregion
        #region Statics
        public static bool Equivalents (Fraction f1, Fraction f2)
        {
            bool iguals = false;
            Fraction f1Copy = new Fraction(f1);
            Fraction f2Copy = new Fraction(f2);
            f1Copy.Simplify();
            f2Copy.Simplify();
            if (f1Copy.a_sign == f2Copy.a_sign && f1Copy.a_num == f2Copy.a_num && f1Copy.a_den == f2Copy.a_den)
                iguals = true;
            return iguals;
        }
        public static Fraction Add(Fraction f1, Fraction f2)
        {
            Fraction f1Copy = new Fraction(f1);
            Fraction f2Copy = new Fraction(f2);
            f1Copy.Sum(f2Copy);
            return f1Copy;
        }
        public static Fraction Substract(Fraction f1, Fraction f2)
        {
            Fraction f1Copy = new Fraction(f1);
            Fraction f2Copy = new Fraction(f2);
            if (f2Copy.a_sign == '-')
                f2Copy.a_sign = '+';
            else
                f2Copy.a_sign = '-';
            f1Copy.Sum(f2Copy);
            return f1Copy;
        }
        public static Fraction Multiply(Fraction f1, Fraction f2)
        {
            Fraction f1Copy = new Fraction(f1);
            Fraction f2Copy = new Fraction(f2);
            f1Copy.Multiply(f2Copy);
            return f1Copy;
        }
        public static Fraction Divide(Fraction f1, Fraction f2)
        {
            Fraction f1Copy = new Fraction(f1);
            Fraction f2Copy = new Fraction(f2);
            f1Copy.Divide(f2Copy);
            return f1Copy;
        }
        #endregion
        #region Operadors
        public static bool operator == (Fraction f1, Fraction f2)
        {
            if (Equivalents(f1, f2))
                return true;
            else
                return false;
        }
        public static bool operator != (Fraction f1, Fraction f2)
        {
            if (Equivalents(f1, f2))
                return false;
            else
                return true;
        }
        public static Fraction operator + (Fraction f1, Fraction f2)
        {
            return Add(f1, f2);
        }
        public static Fraction operator - (Fraction f1, Fraction f2)
        {
            return Substract(f1, f2);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return Multiply(f1, f2);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return Divide(f1, f2);
        }
        public static Fraction operator -(Fraction f)
        {
            Fraction fCopy = new Fraction(f);
            if (fCopy.a_sign == '-')
                fCopy.a_sign = '+';
            else
                fCopy.a_sign = '-';
            return fCopy;
        }
        public static Fraction operator ++(Fraction f)
        {
            Fraction one = new Fraction(1, 1, '+');
            return Add(one, f);
          
        }
        public static Fraction operator --(Fraction f)
        {
            Fraction one = new Fraction(1, 1, '+');
            return Substract(one, f);
        }
        public static Fraction operator !(Fraction f)
        {
            Fraction fcopy = new Fraction(f);
            int aux = fcopy.a_num;
            fcopy.a_num = fcopy.a_den;
            fcopy.a_den = aux;
            return fcopy;
        }
        #endregion
        #region Conversions
        public static explicit operator double (Fraction f)
        {
            return f.RealValue;
        }
        public static implicit operator Fraction (int i)
        {
            Fraction result = new Fraction();
            if (i>0)
            {
                result = new Fraction(i, 1, '+');
            }
            else
            {
                i = -i;
                result = new Fraction(i, 1, '-');
            }
            return result;
        }
        #endregion
        #region Overrides

        public override string ToString()
        {
            string output;
            
            if(this.a_num%this.a_den == 0)
            {
                if (this.a_num == 0)
                    output = "0";
                else
                    output = $"{a_sign}{a_num / a_den}";
            }
            else
                output = $"{this.a_sign}{this.a_num}/{this.a_den}";
            return output;
        }
        public override bool Equals(object obj)
        {
            bool areEqual = true;
            if (this is null) areEqual = obj is null;
            else if (obj is Fraction f)
            {
                areEqual = Fraction.Equivalents(this, f);
            }
            else areEqual = false;
            return areEqual;
        }

        #endregion
    }
}
 