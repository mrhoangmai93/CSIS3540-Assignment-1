using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AS1ProjectTeam01
{

    public partial class CarListingsForm : Form
    {
        // Init list string to hold list of selections
        List<string> selectedYearList = new List<string>();
        List<string> selectedMakeList = new List<string>();
        List<string> selectedColorList = new List<string>();
        List<string> selectedDealerList = new List<string>();

        //global LINQ 
        IEnumerable<Car> query = null;

        // Init list Car to hold list of all cars
        private List<Car> listCars;

        public CarListingsForm()
        {
            InitializeComponent();

            // Initilize and setup form
            InitLoad();

            // Bring the form back after loaded XML
            BringToTop();

            // Assign event handler
            resetButton.Click += Reset;
            searchEngineSize.CheckedChanged += FilterHandler;
            searchPrice.CheckedChanged += FilterHandler;
            txtMinPrice.TextChanged += FilterHandler;
            txtMaxPrice.TextChanged += FilterHandler;
            txtMinEngineSize.TextChanged += FilterHandler;
            txtMaxEngineSize.TextChanged += FilterHandler;
        }

        /// <summary>
        /// Restore all eventHandler and set all listboxes selected
        /// </summary>
        public void ResetToDefault()
        {
            // Unregistered listbox SelectedIndexChanged event
            yearsListBox.SelectedIndexChanged -= FilterHandler;
            colorsListBox.SelectedIndexChanged -= FilterHandler;
            makesListBox.SelectedIndexChanged -= FilterHandler;
            dealersListBox.SelectedIndexChanged -= FilterHandler;

            // Select all options AND update their relative List<string> 
            SelectAllInListBox(makesListBox);
            selectedMakeList = UpdateSelectItem(makesListBox);
            
            SelectAllInListBox(colorsListBox);
            selectedColorList = UpdateSelectItem(colorsListBox);
            
            SelectAllInListBox(yearsListBox);
            selectedYearList = UpdateSelectItem(yearsListBox);
            
            SelectAllInListBox(dealersListBox);
            selectedDealerList = UpdateSelectItem(dealersListBox);

            //// register listbox SelectedIndexChanged event
            yearsListBox.SelectedIndexChanged += FilterHandler;
            colorsListBox.SelectedIndexChanged += FilterHandler;
            makesListBox.SelectedIndexChanged += FilterHandler;
            dealersListBox.SelectedIndexChanged += FilterHandler;
            populateLowerTable();
        }


        /// <summary>
        /// Update data of DataListView
        /// </summary>
        public void SelectAllInListBox(ListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetSelected(i, true);
            }
        }

        
       
        /// <summary>
        /// Event handler for four listboxes
        /// </summary>
        private void FilterHandler(object sender, EventArgs e)
        {
            ListBox triggeredLists = sender as ListBox;
            
            if(triggeredLists != null)
            {
                string name = triggeredLists.Name;
                switch (name)
                {
                    case "listYears":
                        selectedYearList = UpdateSelectItem(triggeredLists);
                        break;
                    case "listColors":
                        selectedColorList = UpdateSelectItem(triggeredLists);
                        break;
                    case "listDealers":
                        selectedDealerList = UpdateSelectItem(triggeredLists);
                        break;
                    case "listMakes":
                        selectedMakeList = UpdateSelectItem(triggeredLists);
                        break;

                }
            }
           
            populateLowerTable();
        }

        /// <summary>
        /// Get value of selectedItem from listbox and save them to a list for further use
        /// </summary>
        public List<string> UpdateSelectItem(ListBox triggeredLists)
        {
            List<string> tempList = new List<String>();
            for (int i = 0; i < triggeredLists.SelectedItems.Count; i++)
            {
                string temp = triggeredLists.SelectedItems[i].ToString();
                tempList.Add(temp);
            }
            return tempList;
        }
        /// <summary>
        /// Filter and display cars based on user decision
        /// </summary>
        public void populateLowerTable()
        {
            // Query all selected options
            query = listCars.Where(car => (
            selectedYearList.Contains(car.Year.ToString())) 
            && (selectedColorList.Contains(car.Color)) 
            && (selectedDealerList.Contains(car.Dealer)) 
            && (selectedMakeList.Contains(car.Make))
            );
            // Query price if checked
            if (searchPrice.Checked) {
                // Validate input before process query
                if (TxtBoxValidation(searchPrice, txtMinPrice,txtMaxPrice ))
                {
                    query = query.Where(car =>
                      (decimal)car.Price <= decimal.Parse(txtMaxPrice.Text)
                      && (decimal)car.Price >= decimal.Parse(txtMinPrice.Text)
                  );
                }
                
                  
            }

            // Query Engine size if checked
            if (searchEngineSize.Checked) {
                // Validate input before process query
                if (TxtBoxValidation(searchEngineSize, txtMinEngineSize,txtMaxEngineSize))
                {
                    query = query.Where(car => (decimal)car.EngineSize <= decimal.Parse(txtMaxEngineSize.Text)
                      && (decimal)car.EngineSize >= decimal.Parse(txtMinEngineSize.Text)
                  );
                }
              
            }
           
            // Display to DataGridView
            ConvertListToDataGridView(query.ToList(), dataSelectedCars);

            // Count selected cars
            var count = query.Count();
            // If count is one or more calculate the average
            if (query.Count() > 0)
            {
                var average = query.Select(car => car.Price).Average();
                labelAverage.Text = average.ToString("C2");
            }
            else
            {
                labelAverage.Text = 0.ToString("C2");
            }
            labelCount.Text = count.ToString();
        }
        /// <summary>
        /// Validate user input
        /// </summary>
        public bool TxtBoxValidation(CheckBox checkbox, TextBox minTxt, TextBox maxTxt)
        {
            // try parse string to decimal
            try
            {
                decimal min = decimal.Parse(minTxt.Text);
                decimal max = decimal.Parse(maxTxt.Text);
                if (min > max)
                {
                    return errorForTxtBox(checkbox, "minmax");
                }
            }
            catch (Exception e)
            {
                return errorForTxtBox(checkbox);
            }


            return true;

        }
        /// <summary>
        /// Print error message for textbox input
        /// </summary>
        public bool errorForTxtBox(CheckBox checkbox, string input = "")
        {
            string print;
            if (input == "minmax")
            {
                print = "minimum value should be smaller than maximum value";
            }
            else
            {
                print = "Price is missing or is not a number";
            }
            MessageBox.Show(print);
            checkbox.Checked = false;
            return false;
        }


        #region Serialize XML doc
        /// <summary>
        /// Get the car listings from an xml file
        /// </summary>
        public List<Car> GetXmlCarListingsSerialize()
        {
            // Try open file dialog and get file name
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\.."),
                };
                // If user click OK, perform file load
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Define doc root of the XML
                    XmlRootAttribute xRoot = new XmlRootAttribute();
                    xRoot.ElementName = "ArrayOfCar";
                    xRoot.IsNullable = true;
                    // Init serializer
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Car>), xRoot);
                    // Init file reader and open the file
                    StreamReader carsFile = new StreamReader(openFileDialog.FileName);
                    // Deserialize xml file into list
                    listCars = xmlFormat.Deserialize(carsFile) as List<Car>;

                    // Sort all cars by Make, Price, Year and Color
                    var carsSorted = from car in listCars
                                    orderby car.Make, car.Price, car.Year, car.Color
                                 select car;
                    listCars = carsSorted.ToList();
                    carsFile.Close();
                }
                else
                {
                    // Quit the app
                    System.Environment.Exit(1);

                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                // Quit the app
                System.Environment.Exit(1);
            }
            return listCars;
        }
        #endregion
        #region Bring form to top
        /// <summary>
        /// Bring the form back to top
        /// </summary>
        public void BringToTop()
        {
            // Show the current form
            this.Show();
            // Keeps the current topmost status of form
            bool top = TopMost;
            // Brings the form to top
            TopMost = true;
            // Set form's topmost status back to whatever it was
            TopMost = top;
        }
        #endregion

        

        /// <summary>
        /// Reset to default state
        /// </summary>
        private void Reset(object sender, EventArgs e)
        {
            ResetCheckBoxes();
            ResetToDefault();
        }
        /// <summary>
        /// Reset all checkboxes and textboxes
        /// </summary>
        public void ResetCheckBoxes()
        {
            // Set search checkbox to false
            searchPrice.Checked = false;
            searchEngineSize.Checked = false;
            // Set textbox to empty
            txtMaxEngineSize.Text = "";
            txtMinEngineSize.Text = "";
            txtMaxPrice.Text = "";
            txtMinPrice.Text = "";
        }
        /// <summary>
        // Init list of columns 
        /// </summary>
        public DataGridViewTextBoxColumn[] GetListColumns()
        {
            DataGridViewTextBoxColumn[] arrayDgc = new DataGridViewTextBoxColumn[6];
            arrayDgc[0] = GetDataGrid("Make");
            arrayDgc[1] = GetDataGrid("Year");
            arrayDgc[2] = GetDataGrid("Color");
            arrayDgc[3] = GetDataGrid("Engine Size");
            arrayDgc[4] = GetDataGrid("Price");
            arrayDgc[5] = GetDataGrid("Dealer");
            return arrayDgc;
        }
        /// <summary>
        // Wrapper method for all the initial load
        /// </summary>
        public void InitLoad()
        {
            // Load XML file into a list
            listCars = GetXmlCarListingsSerialize();

            // Setting up and format UI
            SetDataGridView(dataAllCars);
            SetDataGridView(dataSelectedCars);

            yearsListBox.SelectionMode = SelectionMode.MultiExtended;
            colorsListBox.SelectionMode = SelectionMode.MultiExtended;
            makesListBox.SelectionMode = SelectionMode.MultiExtended;
            dealersListBox.SelectionMode = SelectionMode.MultiExtended;

            // Init array of 6 DataGridViewTextBoxColumn and assign column
            // Add column to DataGridView
            dataAllCars.Columns.AddRange(GetListColumns());
            dataSelectedCars.Columns.AddRange(GetListColumns());
            // Format Price column to currency
            dataAllCars.Columns[4].DefaultCellStyle.Format = "c";
            dataSelectedCars.Columns[4].DefaultCellStyle.Format = "c";

            // Display all cars
            ConvertListToDataGridView(listCars, dataAllCars);
            // Display selected cars
            populateLowerTable();

            // Query Makes list
            var makesList = listCars
                .GroupBy(car => car.Make)
                .Select(g => g.First())
                .Select(c => c.Make.ToString());
            // Assign data to list box
            makesListBox.DataSource = makesList.ToList();
            // Query Colors list
            var colorsList = listCars
                .GroupBy(car => car.Color)
                .Select(g => g.First())
                .OrderBy(car => car.Color)
                .Select(c => c.Color.ToString());
            // Assign data to list box
            colorsListBox.DataSource = colorsList.ToList();
            // Query Years list
            var yearsList = listCars
                .GroupBy(car => car.Year)
                .Select(g => g.First())
                .OrderBy(c => c.Year)
                .Select(c => c.Year.ToString());
            // Assign data to list box
            yearsListBox.DataSource = yearsList.ToList();
            // Query Dealers list
            var dealersList = listCars
                .GroupBy(car => car.Dealer)
                .Select(g => g.First())
                .OrderBy(car => car.Dealer)
                .Select(c => c.Dealer.ToString());
            // Assign data to list box
            dealersListBox.DataSource = dealersList.ToList();

            // Set default
            ResetToDefault();
            // Calculate all Cars
            var count = listCars.Count();
            var average = listCars.Select(car => car.Price).Average();
            // Append string to labels
            lblCountAll.Text = count.ToString();
            lblAveragePriceAll.Text = Convert.ToDecimal(average).ToString("C");

        }

        /// <summary>
        /// Multile settings for datagridview
        /// </summary>
        public void SetDataGridView(DataGridView gridView)
        {
            gridView.Columns.Clear(); // any columns created by the designer, get rid of them
            gridView.ReadOnly = true; // no cell editing allowed
            gridView.AllowUserToAddRows = false; // no rows can be added or deleted
            gridView.AllowUserToDeleteRows = false;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gridView.RowHeadersVisible = false;
            gridView.AutoSize = false; // don't autosize the cells
                                       // right justify everything
            gridView.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight;
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

       
        /// <summary>
        /// Init new DataGridViewTextBoxColumn and set headerText
        /// </summary>
        /// <returns>
        /// DataGridViewTextBoxColumn
        /// </returns>
        private DataGridViewTextBoxColumn GetDataGrid(string headerText)
        {
            DataGridViewTextBoxColumn temp = new DataGridViewTextBoxColumn();
            temp.HeaderText = headerText;
            return temp;
        }
        /// <summary>
        /// Update data of DataListView
        /// </summary>
        private void ConvertListToDataGridView(List<Car> list, DataGridView dataGridView)
        {
            // Clear current data
            dataGridView.Rows.Clear();

            // Loop through the list and append to row
            foreach (Car car in list)
            {
                dataGridView.Rows.Add(
                    car.Make, 
                    car.Year, 
                    car.Color, 
                    car.EngineSize, 
                    car.Price, 
                    car.Dealer);
            }
        }
    }
}
