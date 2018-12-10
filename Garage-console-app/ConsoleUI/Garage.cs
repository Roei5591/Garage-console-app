using System;
using Ex03GarageLogic;

namespace ConsoleUI
{
    class Garage
    {
        const string v_QuitString = "Quit";

        readonly string[] v_MainMenuOptions = {
            "Insert a new car to the garage",
            "Display vehicles currently in garage",
            "Change status for existing vehicle",
            "Inflate tires to maximum",
            "Refuel vehicle (fuel-based)",
            "Charge vehicle (electric)",
            "Display vehicle information",
            v_QuitString
            };

        readonly string[] v_FiltersMenu =
        {
            "No Filter - Display All Vehicles",
            "Vehicles In Repair",
            "Vehicles Repaired",
            "Vehicles Paid For",
        };

        readonly string[] v_StatusMenu =
        {
            "In Repair",
            "Repaired",
            "Paid For",
        };

        GarageManger m_Garage = new GarageManger();

        void printMainTitle()
        {

            string car = String.Format(
@"        -          __
     --          ~( @\   \
    ---   _________]_[__/_>________
         /  ____ \ <>     |  ____  \
        =\_/ __ \_\_______|_/ __ \__D
    ________(__)_____________(__)____");

            string title = String.Format(
@"=================================================
|         Welcome To Guy Ronen's Garage         |
=================================================
 
                 -------------
                 | Main Menu |
                 -------------
");

            Console.WriteLine(car + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        private int GetMainMenuSelectionFromUser()
        {
            int o_Selection;
            do
            {
                printMainTitle();
                printStringArrayAsOptions(v_MainMenuOptions);
            }
            while (false == readMenuOptionFromUser(v_MainMenuOptions.Length, out o_Selection));
            return o_Selection;
        }

        private void printStringArrayAsOptions(string[] i_StringArray)
        {
            for (int i = 0; i < i_StringArray.Length; i++)
            {
                int currentPresetNumber = i + 1;
                Console.WriteLine(currentPresetNumber + ".    " + i_StringArray[i]);
            }
            Console.Write("Enter a number [1 to " + i_StringArray.Length + "]: ");
        }

        private int ChoosePreset()
        {
            Console.Clear();
            Console.WriteLine("Choose from the available options:" + Environment.NewLine);
            VehicleMaker maker = new VehicleMaker();
            int presetNumber = getValidInputFromUser(maker.GetVehicleOptions());
            return presetNumber;
        }

        private int getValidInputFromUser(string[] i_Options)
        {
            int selection;
            do
            {
                printStringArrayAsOptions(i_Options);
            }
            while (false == readMenuOptionFromUser(i_Options.Length, out selection));

            return selection;
        }

        private void createAndInsertVehicle()
        {
            int preset = ChoosePreset();
            Vehicle vehicleToAdd = CreateNewVehicle(preset);
            m_Garage.InsertVehicle(vehicleToAdd);
        }

        private bool readMenuOptionFromUser(int i_numberOfOptions, out int o_Selection)
        {
            string inputFromUser;
            bool isNumber;
            bool legalInput;

            inputFromUser = Console.ReadLine();
            isNumber = int.TryParse(inputFromUser, out o_Selection);

            if (isNumber && o_Selection <= i_numberOfOptions && o_Selection > 0)
            {
                legalInput = true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Illegal input! Please try again:");
                Console.ResetColor();
                legalInput = false;
            }

            return legalInput;
        }

        private Vehicle CreateNewVehicle(int i_Selection)
        {
            VehicleMaker vehicleMaker = new VehicleMaker();
            string userAnswer = "";

            vehicleMaker.CreateVehicleFromPreset(i_Selection);

            string[] commonQuestions = vehicleMaker.GetCommonVehiclePropertyNames();

            for (int i = 0; i < commonQuestions.Length; i++)
            {
                bool invalidAnswer = true;
                
                while (invalidAnswer)
                {
                    try
                    {
                        Console.Write(Environment.NewLine + "Please enter data for: ");
                        Console.WriteLine(commonQuestions[i]);
                        userAnswer = Console.ReadLine();
                        vehicleMaker.SetCommonVehicleProperty(commonQuestions[i], userAnswer);
                        invalidAnswer = false;
                    }
                    catch(Exception e)
                    {
                        printExceptionMessage(e);
                    }
                }
                
            }

            string[] specialQuestions = vehicleMaker.GetSpecialVehicleParameterNames();

            for (int i = 0; i < specialQuestions.Length; i++)
            {
                bool invalidAnswer = true;
               
                while (invalidAnswer)
                {
                    try
                    {
                        Console.Write(Environment.NewLine + "Please enter data for: ");
                        Console.WriteLine(specialQuestions[i]);
                        userAnswer = Console.ReadLine();
                        vehicleMaker.SetSpecialVehicleParameter(specialQuestions[i], userAnswer);
                        invalidAnswer = false;
                    }
                    catch (Exception e)
                    {
                        printExceptionMessage(e);
                    }
                }
                
            }

            return vehicleMaker.FinalizeVehicle();
        }

        private void printExceptionMessage(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception detected:");
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }

        private void printPressAnyKeyToContinue()
        {
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }

        private void displayVehiclesInGarage()
        {
            Console.Clear();
            int filterInputFromUser = getValidInputFromUser(v_FiltersMenu);
            int filterNumberInArray = filterInputFromUser - 1;
            string vehiclesToDisplay;

            if (filterNumberInArray == 0)
            {
                vehiclesToDisplay = m_Garage.GetLicenseNumbersCurrentlyInTheGarage();
            }
            else
            {
                eStatus status = (eStatus)filterNumberInArray;
                vehiclesToDisplay = m_Garage.GetLicenseNumbersCurrentlyInTheGarage(status);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Environment.NewLine + "The Following Vehicles Match Your Selection:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(vehiclesToDisplay);
            Console.ResetColor();
            printPressAnyKeyToContinue();
        }

        private void executeSelection(int i_Action)
        {
            switch (i_Action)
            {
                case 1:
                    createAndInsertVehicle();
                    break;
                case 2:
                    displayVehiclesInGarage();
                    break;
                case 3:
                    changeStatusInGarage();
                    break;
                case 4:
                    inflateTiresToMaximum();
                    break;
                case 5:
                    refuelFuelVehicle();
                    break;
                case 6:
                    chargeElectricBasedVehicle();
                    break;
                case 7:
                    printDetails();
                    break;
                default:
                    break;
            }
        }

        private void changeStatusInGarage()
        {

            int selection;

            Console.Clear();

            string input = readExistingLicenceNumberFromUser();

            do
            {
                Console.Clear();
                Console.WriteLine("Choose new status options:" + Environment.NewLine);
                printStringArrayAsOptions(v_StatusMenu);
            }
            while (false == readMenuOptionFromUser(v_StatusMenu.Length, out selection));

            m_Garage.ChangeVehicleStatus(input, (eStatus)selection);
        }

        private string readExistingLicenceNumberFromUser()
        {
            const bool v_InvalidUserInput = true;
            string input;

            Console.Clear();
            Console.WriteLine("Enter a license number" + Environment.NewLine);
            input = Console.ReadLine();

            while (v_InvalidUserInput)
            {
                if (m_Garage.VehicleExists(input) == true)
                {
                    break;
                }
                else
                {
                    throw new Exception("Vehicle doesn't exist");
                }
            }

            return input;
        }

        private void refuelFuelVehicle()
        {

            int fuelTypeSelection;
            float fuelAmountSelection;
            string inputAmount;

            string inputLicenceNumber = readExistingLicenceNumberFromUser();
            string[] fuelTypes;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose type of fuel:" + Environment.NewLine);
                fuelTypes = Enum.GetNames(typeof(eFuelType));
                printStringArrayAsOptions(fuelTypes);
            }
            while (false == readMenuOptionFromUser(fuelTypes.Length, out fuelTypeSelection));

            Console.Clear();
            Console.WriteLine("Enter Amout of fuel:" + Environment.NewLine);
            inputAmount = Console.ReadLine();

            while (float.TryParse(inputAmount, out fuelAmountSelection) == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid input , Enter Amout of fuel:" + Environment.NewLine);
                inputAmount = Console.ReadLine();
            }

            try
            {
                m_Garage.RefuelFuelVehicle(inputLicenceNumber, (eFuelType)fuelTypeSelection, fuelAmountSelection);
            }
            catch (Exception ex)
            {
                printExceptionMessage(ex);
                printPressAnyKeyToContinue();
            }
        }

        private void chargeElectricBasedVehicle()
        {

            float chargeAmountSelection;
            string inputAmount;

            string inputLisenceNumber = readExistingLicenceNumberFromUser();

            Console.Clear();
            Console.WriteLine("Enter Amout to charge:" + Environment.NewLine);
            inputAmount = Console.ReadLine();

            while (float.TryParse(inputAmount, out chargeAmountSelection) == false)
            {
                Console.Clear();
                Console.WriteLine("Invalid input , Enter Amout to charge::" + Environment.NewLine);
                inputAmount = Console.ReadLine();
            }

            try
            {
                m_Garage.ChargeElectricBasedVehicle(inputLisenceNumber, chargeAmountSelection);
            }
            catch (Exception ex)
            {
                printExceptionMessage(ex);
                printPressAnyKeyToContinue();
            }
        }

        private void inflateTiresToMaximum()
        {
            string input = readExistingLicenceNumberFromUser();
            m_Garage.InflateTiresToMaximum(input);
        }

        private void printDetails()
        {
            string inputLicenseNumber;

            try
            {
                inputLicenseNumber = readExistingLicenceNumberFromUser();
                Console.WriteLine(m_Garage.GetVehicleDetails(inputLicenseNumber));
            }
            catch(Exception e)
            {
                printExceptionMessage(e);
            }

            printPressAnyKeyToContinue();
        }

        public void RunGarage()
        {
            bool v_KeepRunning = true;
            while (v_KeepRunning)
            {
                Console.Clear();
                int action = GetMainMenuSelectionFromUser();
                int actionLocationInOptionsArray = action - 1;
                executeSelection(action);
                if (v_MainMenuOptions[actionLocationInOptionsArray].Equals(v_QuitString))
                {
                    v_KeepRunning = false;
                }

            }

        }


    }
}
