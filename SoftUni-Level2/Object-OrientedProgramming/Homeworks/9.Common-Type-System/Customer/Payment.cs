using System;

namespace Customer
{
    public class Payment
    {
        private string productName;
        private decimal productPrice;

        public Payment(string productName, decimal productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ProductName");
                }

                this.productName = value;
            }
        }

        public decimal ProductPrice
        {
            get { return this.productPrice; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("ProductPrice");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ProductPrice");
                }

                this.productPrice = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product Name: {0}, Product Price: {1}\n", this.productName, this.productPrice);
        }
    }
}