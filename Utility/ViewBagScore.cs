using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ViewBagScore
    {
        public static double CalculateScore(double score)
        {
            if (score / 100 > 1)
            {
                score = Math.Round(score / 100, 2);
            }
            else if (score / 10 > 1)
            {
                score = Math.Round(score / 10, 2);
            }
            else
            {
                score = Math.Round(score, 2);
            }

            return score;
        }
    }
}
