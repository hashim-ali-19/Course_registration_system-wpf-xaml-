using System;
using System.Windows;

namespace RegistrationApp
{
    public partial class MainWindow : Window
    {
        private bool isLoaded = false;

        private double feeCSharp = 5000;
        private double feeJava = 4500;
        private double feeJavaScript = 4000;
        private double feePython = 3500;
        private double feeROR = 6000;

        public MainWindow()
        {
            InitializeComponent();
        }

        // WINDOW LOADED EVENT
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            isLoaded = true;
            rbBeginner.IsChecked = true;
            CalculateFee();
        }
        // COURSE CHECKBOX CHANGED EVENT
        private void Course_Changed(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            CalculateFee();
        }
        // SKILL LEVEL RADIO BUTTON CHANGED EVENT
        private void SkillLevel_Changed(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            CalculateFee();
        }

        // CALCULATE BUTTON CLICK EVENT
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateFee();
        }

        // RESET BUTTON CLICK EVENT
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();

            chkCSharp.IsChecked = false;
            chkJava.IsChecked = false;
            chkJavaScript.IsChecked = false;
            chkPython.IsChecked = false;
            chkROR.IsChecked = false;

            rbBeginner.IsChecked = true;

            lblBaseFee.Text = "Rs. 0";
            lblDiscount.Text = "0%";
            lblDiscountAmount.Text = "Rs. 0";
            lblTotalFee.Text = "Rs. 0";

            MessageBox.Show("Form Reset Successfully!",
                           "Reset",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
        }

        // SUBMIT BUTTON CLICK EVENT - WITH VALIDATION
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // VALIDATION 1: Check if name is empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "ERROR: Please enter your name!\n\n" +
                    "Name field cannot be empty.\n\n" +
                    "NOT REGISTERED",
                    "Name Required",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            // VALIDATION 2: Check if any course is selected
            if (!IsAnyCourseSelected())
            {
                MessageBox.Show(
                    "ERROR: Please select at least one course!\n\n" +
                    "You must select one or more courses.\n\n" +
                    "NOT REGISTERED",
                    "Course Selection Required",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            // SUCCESS - SUCCESSFULLY REGISTERED
            string skillLevel = GetSkillLevel();
            string coursesSelected = GetSelectedCourses();

            string successMessage =
                "✓✓✓ SUCCESSFULLY REGISTERED ✓✓✓\n\n" +
                "═══════════════════════════════════════\n" +
                "REGISTRATION DETAILS:\n" +
                "═══════════════════════════════════════\n\n" +
                "Student Name: " + txtName.Text + "\n" +
                "Skill Level: " + skillLevel + "\n\n" +
                "SELECTED COURSES:\n" +
                coursesSelected + "\n" +
                "═══════════════════════════════════════\n" +
                "FEE BREAKDOWN:\n" +
                "═══════════════════════════════════════\n" +
                "Base Fee: " + lblBaseFee.Text + "\n" +
                "Discount Percentage: " + lblDiscount.Text + "\n" +
                "Discount Amount: " + lblDiscountAmount.Text + "\n" +
                "\n" +
                "TOTAL PAYABLE: " + lblTotalFee.Text + "\n" +
                "═══════════════════════════════════════\n\n" +
                "Thank you for registering with us!\n" +
                "Your registration has been submitted successfully.";

            MessageBox.Show(successMessage,
                           "✓ SUCCESSFULLY REGISTERED",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);

            btnReset_Click(null, null);
        }
        // HELPER METHOD: Check if any course is selected
        private bool IsAnyCourseSelected()
        {
            if (chkCSharp.IsChecked == true) return true;
            if (chkJava.IsChecked == true) return true;
            if (chkJavaScript.IsChecked == true) return true;
            if (chkPython.IsChecked == true) return true;
            if (chkROR.IsChecked == true) return true;

            return false;
        }

        // HELPER METHOD: Get selected courses
        private string GetSelectedCourses()
        {
            string courses = "";

            if (chkCSharp.IsChecked == true)
                courses += "✓ C# Programming - Rs. 5,000\n";

            if (chkJava.IsChecked == true)
                courses += "✓ Java Programming - Rs. 4,500\n";

            if (chkJavaScript.IsChecked == true)
                courses += "✓ JavaScript and Web Dev - Rs. 4,000\n";

            if (chkPython.IsChecked == true)
                courses += "✓ Python Programming - Rs. 3,500\n";

            if (chkROR.IsChecked == true)
                courses += "✓ Ruby on Rails - Rs. 6,000\n";

            return courses;
        }
        // MAIN CALCULATION METHOD
        private void CalculateFee()
        {
            double totalFee = 0;

            if (chkCSharp.IsChecked == true)
                totalFee += feeCSharp;

            if (chkJava.IsChecked == true)
                totalFee += feeJava;

            if (chkJavaScript.IsChecked == true)
                totalFee += feeJavaScript;

            if (chkPython.IsChecked == true)
                totalFee += feePython;

            if (chkROR.IsChecked == true)
                totalFee += feeROR;

            double discountPercent = 0;
            string discountText = "0%";

            if (rbIntermediate.IsChecked == true)
            {
                discountPercent = 0.10;
                discountText = "10%";
            }
            else if (rbAdvanced.IsChecked == true)
            {
                discountPercent = 0.15;
                discountText = "15%";
            }

            double discountAmount = totalFee * discountPercent;
            double finalFee = totalFee - discountAmount;

            lblBaseFee.Text = "Rs. " + totalFee.ToString("N0");
            lblDiscount.Text = discountText;
            lblDiscountAmount.Text = "Rs. " + discountAmount.ToString("N0");
            lblTotalFee.Text = "Rs. " + finalFee.ToString("N0");
        }
        // HELPER METHOD: Get skill level
        private string GetSkillLevel()
        {
            if (rbBeginner.IsChecked == true)
                return "Beginner (0% Discount)";
            else if (rbIntermediate.IsChecked == true)
                return "Intermediate (10% Discount)";
            else if (rbAdvanced.IsChecked == true)
                return "Advanced (15% Discount)";
            else
                return "Unknown";
        }
    }
}