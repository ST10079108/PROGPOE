using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static List<RecipeClass> RecipeList;// list of recipes, mainly used for headings
        private static List<IngredientClass> IngredientsList; // list of ingredients
        private static List<StepClass> StepsList;  //list of steps
        private static Dictionary<string, string> recipeDictionary;// recipe dictionary

        public static string recipeDesc, ingredientsDesc, stepsDesc, fullDescription;
        public static string recipeName;
        public static double numberOfIngredients, numberOfSteps, ingredientNumber;
        public static string ingredientName, ingredientMeasurement, ingredientFoodGroup, unitOfMeasurement;
        public static double ingredientCalories, ingredientQuantity, stepNumber;
        public static string stepDescription, tempIngList, tempStepList;
        public static double totalCalories = 0; // total calories is calculated through iterations of adding ingredients

        public MainWindow()
        {
            InitializeComponent();
            RecipeList = new List<RecipeClass>();
            IngredientsList = new List<IngredientClass>();
            StepsList = new List<StepClass>();
            recipeDictionary = new Dictionary<string, string>();
        }

        //Navigation


        private void btnAddRecipes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            DisplayAllRecipes dispall = new DisplayAllRecipes(recipeDictionary);
            dispall.Show();
            this.Hide();
        }

        private void btnDisplayARecipe_Click(object sender, RoutedEventArgs e)
        {
            DisplayOneRecipe dispone = new DisplayOneRecipe(recipeDictionary);
            dispone.Show();
            this.Hide();
        }
        //Navigation

        private void txtSteps_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNumIngredients_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtRName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFoodGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtIName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtIQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtINumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtIUOM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtICalories_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeClass recipe;

            string recipeName = txtRName.Text;
            double recipeNumIngredients = Convert.ToDouble(txtNumIngredients.Text);
            double recipeNumSteps = Convert.ToDouble(txtNumSteps.Text);



            stepNumber = Convert.ToDouble(txtNumSteps.Text);
            stepDescription = txtSDescription.Text;

            // Error validation for empty credentials
            if (string.IsNullOrEmpty(recipeName) || !double.TryParse(txtNumIngredients.Text, out recipeNumIngredients) || !double.TryParse(txtNumSteps.Text, out recipeNumSteps)
                )


            {
                // If at least one field is empty, give user a warning
                MessageBox.Show("Please ensure all fields have been entered.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                // If all the fields have been populated.
                // Create a new RecipeClass object
                recipe = new RecipeClass(recipeName, recipeNumIngredients, recipeNumSteps);


                //Build Ingredients descriprion
                foreach (var ingredient in IngredientsList)
                {
                    ingredientsDesc += $" {ingredient.Quantity})  {ingredient.Number} {ingredient.UnitOfMeasurement} of {ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}\n";
                }


                //Build Steps descriprion
                foreach (var step in StepsList)
                {
                    stepsDesc += $" {step.StepNum})  {step.Desc}\n";
                }

                // Message to display completion
                MessageBox.Show("recipe added successfully.\n" + recipe.ToString() + "\nIngredients\n" + ingredientsDesc + "\nSteps\n" + stepsDesc, "Module Added", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                fullDescription = recipe.ToString() + "\nIngredients\n" + ingredientsDesc + "\nSteps\n" + stepsDesc;
                recipeDictionary.Add(recipeName, fullDescription);

                ClearUI();
                ClearData();

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearUI();
            ClearData();
        }

        private void btnNewStep_Click(object sender, RoutedEventArgs e)
        {
            stepNumber = Convert.ToDouble(txtSNumber.Text);
            stepDescription = txtSDescription.Text;

            // Error validation for empty credentials
            if (!double.TryParse(txtSNumber.Text, out stepNumber) || string.IsNullOrEmpty(stepDescription))


            {
                // If at least one field is empty, give user a warning
                MessageBox.Show("Please ensure all fields have been entered.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                // If all the fields have been populated.
                // Create a new RecipeClass object
                StepsList.Add(new StepClass(stepNumber, stepDescription));

                //// Add object to the DataStore (List)
                //DataStore.Modules.Add(modules);


                // Message to display completion
                MessageBox.Show($"step added successfully.\n {stepNumber})  {stepDescription}\n", "Module Added", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                ClearStepUI();
            }

        }

        private void btnNewIngredient_Click(object sender, RoutedEventArgs e)
        {


            ingredientNumber = Convert.ToDouble(txtINumber.Text);
            ingredientName = txtIName.Text;
            ingredientQuantity = Convert.ToDouble(txtIQuantity.Text);
            ingredientMeasurement = txtIUOM.Text;
            ingredientCalories = Convert.ToDouble(txtICalories.Text);
            ComboBoxItem foodItem = (ComboBoxItem)cmbFoodGroup.SelectedItem;
            ingredientFoodGroup = foodItem.Content.ToString();


            // Error validation for empty credentials
            if (!double.TryParse(txtINumber.Text, out ingredientNumber) || string.IsNullOrEmpty(ingredientName) || !double.TryParse(txtIQuantity.Text, out ingredientQuantity)
                || string.IsNullOrEmpty(ingredientMeasurement) || !double.TryParse(txtICalories.Text, out ingredientCalories) || string.IsNullOrEmpty(ingredientFoodGroup))
            {
                // If at least one field is empty, give user a warning
                MessageBox.Show("Please ensure all fields have been entered.", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                // If all the fields have been populated.
                // Create a new RecipeClass object
                //ingredient = new IngredientClass(ingredientNumber, ingredientName, ingredientQuantity, unitOfMeasurement, ingredientCalories, ingredientFoodGroup);
                IngredientsList.Add(new IngredientClass(ingredientNumber, ingredientName, ingredientQuantity, unitOfMeasurement, ingredientCalories, ingredientFoodGroup));



                // Message to display completion

                MessageBox.Show($" {ingredientQuantity})  {ingredientNumber} {ingredientMeasurement} of {ingredientName} - {ingredientCalories} calories - {ingredientFoodGroup}\n", "Module Added", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                //ClearIngredientUI();
            }
        }

        private void ClearUI()
        {
            txtRName.Text = string.Empty;
            txtNumIngredients.Text = string.Empty;
            txtNumSteps.Text = string.Empty;

            txtSNumber.Text = string.Empty;
            txtSDescription.Text = string.Empty;

            txtINumber.Text = string.Empty;
            txtIName.Text = string.Empty;
            txtIQuantity.Text = string.Empty;
            txtIUOM.Text = string.Empty;
            txtICalories.Text = string.Empty;
            cmbFoodGroup.SelectedIndex = 0;

        }

        private void ClearIngredientUI()//This method clears user input
        {
            txtINumber.Text = string.Empty;
            txtIName.Text = string.Empty;
            txtIQuantity.Text = string.Empty;
            txtIUOM.Text = string.Empty;
            txtICalories.Text = string.Empty;
            cmbFoodGroup.SelectedIndex = 0;
        }

        private void ClearStepUI() //This method clears user input
        {
            txtSNumber.Text = string.Empty;
            txtSDescription.Text = string.Empty;
        }

        private void ClearData() //This method clears previously entered user data
        {
            IngredientsList.Clear();
            RecipeList.Clear();
            StepsList.Clear();
            //recipeDesc = "";
            //ingredientsDesc = "";
            //stepsDesc = "";
            //fullDescription = "";
            //totalCalories = 0;
        }


    }
}