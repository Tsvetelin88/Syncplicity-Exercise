using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncplicityUIFramework.Utils
{
    public static class EmailGenerator
    {
        private const string Domain = "@testmail.com";
        private const string DefaultPrefix = "autotest_user_";

        /// <summary>
        /// Generates a unique, random email address using system Ticks for guaranteed uniqueness.
        /// Format: autotest_user_[DateTimeTicks]@testmail.com
        /// </summary>
        /// <returns>A unique email address (string).</returns>
        public static string GenerateRandomEmail()
        {
            // Ticks provide a highly granular timestamp, ensuring uniqueness across test runs.
            string uniqueId = DateTime.Now.Ticks.ToString();

            return DefaultPrefix + uniqueId + Domain;
        }

        /// <summary>
        /// Generates a unique email address with a specified custom prefix.
        /// Format: [customPrefix]_[DateTimeTicks]@testmail.com
        /// </summary>
        /// <param name="customPrefix">A specific prefix for the email (e.g., "globaladmin").</param>
        /// <returns>A unique email address (string).</returns>
        public static string GenerateRandomEmail(string customPrefix)
        {
            string uniqueId = DateTime.Now.Ticks.ToString();
            // Ensure the custom prefix doesn't end with an underscore already
            if (!customPrefix.EndsWith("_"))
            {
                customPrefix += "_";
            }
            return customPrefix + uniqueId + Domain;
        }
    }
}
