using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2001215896_LeGiaKiet_BTLCN1
{
    class PhepToan
    {
        public double a, b;
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public PhepToan(double a,double b)
        {
            this.a = a;
            this.b = b;
        }
        public PhepToan()
        {

        }

        public double Cong()
        {
            return a + b;
        }
        public double Tru()
        {
            return a - b;
        }
        public double Nhan()
        {
            return a * b;
        }
        public double Chia()
        {
            return a / b;
        }
        public double Can(double c)
        {
            return Math.Sqrt(c);
        }
        public double BinhPhuong(double c)
        {
            return c * c;
        }
        public double MotPhanX(double c)
        {
            return 1 / c;
        }
    }
}
