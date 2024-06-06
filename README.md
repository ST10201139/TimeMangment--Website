# Time Management Application Readme
## Overview
Welcome to the third phase of the Portfolio of Evidence (POE) project! This repository encapsulates the development of an ASP.NET Core web application aimed at revolutionizing time management during a semester.
This web-based solution grants users access to time-tracking functionalities across various devices equipped with a standard web browser.
# Version
- xml version="1.0" encoding="utf-8" version="v4.0" sku=".NETFramework,Version=v4.8"
# Recommended System Requirements
- Operating System : Windows 10 version 1703 or higher :Home,Professional,Education,and Enterprise(LTSC and s are not supported) Hardware : 1.8 GHz or faster processor .Quad -core or better recommended
# Installations
- It is recommended that you use Microsoft Visual Studio 2019 to run the application.
# Objective Expansion
- In this phase, our primary focus is to take the existing time management system, solidified in the desktop application of Part 2, and amplify its utility, reach, and user-friendliness through a web-based interface.
- We aim to cater to a diverse user base, spanning students, working professionals, or individuals seeking a robust, all-in-one tool to manage their study modules and academic workload seamlessly.
# User Registration and Authentication
## User Registration Process:
- The "RegisterView" section serves as the entry point for user registration. Input unique usernames, secure passwords, and valid email addresses, and complete the registration by clicking the "Register" button.

## Forgotten Password or Username:
- Regrettably, the application doesn't currently support password recovery features. In case of forgotten credentials, users are advised to seek assistance from the application administrator.


# Controllers:
## HomeController:
- Manages the main views like Index and Privacy.
- Handles error-related views and caching.
## StudyHoursController:
- Deals with study hours management, including adding, editing, and deleting study hours.
- Utilizes user authentication to track study hours per user.
- Implements a bar graph function to display study hours graphically.
## SemestersController:
- Handles semester-related actions such as adding, editing, and deleting semesters.
- Uses user authentication to associate semesters with specific users.
# ViewModel:
## ModuleViewModel:
- Contains properties for a Module and remaining study hours.
- Likely used to display module-related information along with calculated remaining study hours.
# Models:
## Modules:
- Represents study modules with attributes like ModuleId, ModuleCode, ModuleName, ModuleCredits, etc.
- Contains properties for study-related information like SelfStudyHours, StudyHoursLeft, and links modules to a particular semester and user.
## Semester:
- Represents semesters within the academic year.
- Contains attributes like SemesterId, SemesterName, SemesterWeeks, and StartDate.
- Includes a UserID property to associate semesters with specific users.
## StudyHours:
- Represents hours dedicated to studying for specific modules on particular dates.
- Contains properties like StudyHourId, ModuleId (linked to Modules), StudyDate, and Hours spent studying.
- Utilizes UserID to associate study hours with specific users. 

# Views
## BarGraphFunction View:
- This view renders a bar graph using Chart.js to display the hours spent on different study modules.
- It receives a list of StudyHours objects (List<Final_POE_TimeMangement.Models.StudyHours>) as the model.
- The JavaScript code uses Chart.js to create a bar chart representing the hours spent on various modules.
- It generates a legend with colors next to module names for better visualization.
## DisplayHrs View:
- This view represents the remaining study hours for a specific module.
- It uses the ModuleViewModel (Final_POE_TimeMangement.Controllers.ModuleViewModel) as the model, which contains information about the module and its remaining study hours.
- The view displays the remaining study hours for a particular module and includes a button to show a popup message using SweetAlert when clicked.

- Both views utilize JavaScript libraries (Chart.js and SweetAlert) to enhance the user interface. The BarGraphFunction view presents a visual representation of study hours using a bar chart, while the displayhrs view focuses on displaying remaining study hours for a specific module and triggering a popup message.

# Frequently Asked Questions (FAQs)
## General Questions
**Q:Can I access the web application from any device?**

A: Yes, the web application is designed to be responsive and accessible from various devices, including desktops, laptops, tablets, and smartphones, as long as they have a compatible web browser.

**Q: Will my data be secure on this web platform?**

A: Absolutely. We prioritize data security and employ robust measures to safeguard your information. The application uses secure authentication methods and encryption techniques to protect user data, ensuring confidentiality and privacy.

**Q: How can I view my study progress graphically?**

A: The application provides a graphical representation of your study progress over time. You can access this feature in the dashboard section after logging in, allowing you to visualize your study hours against the ideal study hours per week for each module.

**Q: Can I manage multiple semesters and modules concurrently?**

A: Yes, the web application supports the management of multiple semesters and their respective modules simultaneously. You can easily switch between semesters and add, edit, or remove modules as needed.

**Q: Is the web application compatible with specific web browsers?**

A: The application is compatible with modern web browsers such as Google Chrome, Mozilla Firefox, Microsoft Edge, and Safari. Ensure you are using the latest versions for the best experience.

**Q: Can I customize reminders or notifications for study module schedules?**

A: Currently, the application does not offer custom reminder settings. However, it displays planned study modules for specific days, aiding users in adhering to their schedules when accessing the website.

**Q: How often can I expect updates or improvements to the application**

A: We are committed to continuous improvement. Updates and enhancements will be rolled out periodically, incorporating user feedback, bug fixes, and new features. Users are encouraged to provide feedback and suggestions via our GitHub repository.

**Q: What if I encounter issues or bugs while using the application?**

A: If you encounter any issues, bugs, or have suggestions for improvements, please report them by opening an issue on our GitHub repository. Our team will address these promptly to ensure a smooth user experience.
# License
- This project is licensed under the MIT License. See the LICENSE.md file for details.

# Contact Information
Please communicate with me if you have any queries, comments, or recommendations.
- Please contact Liam Munsamy at ST10201139@vcconnect.edu.za .
- If you encounter any issues or have suggestions for improvements, please feel free to open an issue on the project's GitHub repository.

## Acknowledgements

-> Microsoft (n.d.) 'Creating an Entity Framework Data Model for an ASP.NET MVC Application', [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application [Accessed: 2023/10/11].
