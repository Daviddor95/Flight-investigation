# Flight-investigation-application
> A desktop application that interacts with a Flight Gear simulator app.
> This app displays real time data changes of the flight parameters, throught different charts and diagrams.

<img src = "https://github.com/Daviddor95/Flight-investigation/blob/master/pictures/middleScreen.png" width="600" height="450"></br>

## Whats required for getting started?
### Prerequisites
Download and install .NET 4.7.2, Visual Studio 2019 or higher with WPF framework, and FlightGear Simulator.
#### Dependencies
LiveChrts, LiveCharts.WPF
## Installing
Download and extract the zip from this repository and open the .sln file using Visual studio, or use "git clone" in the terminal:
```sh 
git clone https://github.com/Daviddor95/Flight-investigation
```
Then, enter the location in which the FlightGear simulator is installed in your computer, then go to data\Protocol folder, and then copy the "playback_small.xml" file from the project's "settings" folder to the "Protocol" folder.
Make sure that your computer's firewall isn't blocking either FlightGear simulator or Visual Studio programs. Then, open the FlightGear program on your computer, go to settings, and in the "Additional Settings" field enter the following:
```sh
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
```
Click "Fly", and after you hear "Need help? use help tutorials" start our app (via Visual studio).

## ✨ Special Features ✨
- Player - Controls the FlightGear simulator's playback of the given flight record. Using the slider you can go back and forth or tump to specific time, and using the buttons you can play, pause, stop, control the playback speed, reverse the playback, jump to start/end and more
- Joystick - Shows the changes in the aileron (x-coordinate) and elevator(y-coordinate) 
features through the flight, by the movement of the joystick 
and for showing the changes in the rudder and throttle features through the flight, 
through the movement of the little sliders near the joystick.
You can also see the changes in the values of yaw, pitch, roll, direction, airspeed and altimeter.
- charts - show a graph that emphasizes the changes in a value of the flight feature we choose, compares to another feature.
- another graph that emphasizes the last 30 values of the feature we chose.

## Project Structure
Our project is made out of 3 folders:
- Client - Everything connected to the interaction of our App with the FlightGear App.
- Settings - Includes playback_small.xml and the reg_flight.csv
- Controls - Contains 4 folders: Player, Joystick, Charts and main.

### Every control's folder is responsible for a different aspect:
Joystick is responsible for the joystick and its sliders movement,
player for controlling the playback of the flight through FilghtGear and so on..

### Every controller built using the MVVM architecture:
It contains a Model (A partial class, part of the whole application's Model) which holds the logic behind the controller, 
a ViewModel which hold on the properties to connect between the Model and the View,
and a View which holds the user interface and design and interacts with the ViewModel using data binding.
For every controller, we created an inteface for the ViewModel and for the Model so it would be easy to change the implementation of one controller without affecting the others.
These interfaces extended the INotifyPropertyChanged interface,
which enabled us to notify the properties of the Model and the ViewModel, 
so eventually, the View will change accordingly using the data binding.
Every View of every controller, extends the UserControl class, and they are all used in the main View.
The main folder combines all the controllers together:
Creates a united view, and adds more functions to our Model

### Application demonstration:
https://youtu.be/Sf_riQ1MhFA

## UML:
<img src = "https://github.com/Daviddor95/Flight-investigation/blob/master/pictures/Uml.png" width="650" height="350"></br>


