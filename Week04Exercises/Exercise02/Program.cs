// Import the CourseManagement service to use in the main program
using Students.Management.Library.Service;

// Create an instance of the CourseManagement service
// This service handles all the business logic for the course management system
var service = new CourseManagement();

// Call the Menu method to start the application
// This will display the main menu and handle all user interactions
service.Menu();