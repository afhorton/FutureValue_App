using System.ComponentModel.DataAnnotations;

namespace FutureValueApp.Models
{
    public class FVModel
    {
        [Required(ErrorMessage ="Monthly investment is required")]
        [Range(0, 10000, ErrorMessage ="Monthly investment value must be 0-10000")]
        public decimal MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Annual interest rate is required")]
        [Range(1, 20, ErrorMessage = "Annual interest rate must be 1-20")]
        public decimal AnnualInterestRate { get; set; }

        [Required(ErrorMessage = "Years is required")]
        [Range(1, 100, ErrorMessage = "Years must be 1-100")]
        public int Years { get; set; }

        public decimal? CalculateFutureValue()
        {
            decimal? futureValue = 0;
            decimal? monthlyInterestRate = AnnualInterestRate/ 12 / 100; // as decimal not %
            int? months = Years * 12;
            for(int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) * (1 + monthlyInterestRate);
            }
            return futureValue;
        }

    }
}
