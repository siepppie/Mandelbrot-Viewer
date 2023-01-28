# Mandelbrot Generator
This C# project generates the Mandelbrot fractal using the System.Drawing and System.Windows.Forms libraries.

## Getting Started
1. Clone the repository to your local machine
2. Open the solution file in Visual Studio
3. Build and run the application

## Usage
The application allows the user to adjust the following parameters of the fractal:
* Center (x and y)
* Scale
* Maximum iterations
These parameters can be adjusted by entering values in the corresponding text boxes and clicking the "Update" button. The fractal will be regenerated with the new parameters. The "Reset" button will set the parameters back to their default values.

The application also allows the user to select a color scheme for the fractal by selecting an option from the list box.

The generated fractal is displayed in a PictureBox on the form.

## Code Overview
The Form1 class contains the logic for the user interface and the generation of the fractal. It contains public variables for the fractal parameters, as well as methods for handling button clicks and generating the fractal.

The Math method is responsible for determining the color of each pixel in the fractal based on the current parameters and the selected color scheme. It uses the Mandelbrot algorithm to calculate the value for each pixel, and then assigns a color based on the number of iterations.

The Generate method uses a nested loop to iterate over each pixel in the PictureBox and calls the Math method for each pixel, setting the resulting color to the corresponding pixel in a Bitmap. The Bitmap is then displayed in the PictureBox.
