Envision - StudyMates (CMPT 470)

Readme
Membesr: Francesco Zhang, Daniel Peng, Agassi Cheung

FinalProject:

Steps to run the final project on the vagrant:
    1. vagrant up and vagrant ssh into the virtual machine
    2. cd ..
    3. cd ubuntu\project\cmpt470project\FinalProject
    4. sudo service nginx restart
    5. sudo service mysql restart
    6. dotnet restore
    7. dotnet ef database update
    8. dotnet run

Steps to run tests on this project
    1. cd .. and cd FinalProject.Tests to go to cmpt470project\FinalProject.Tests
    2. dotnet restore
    3. dotnet test


Premade User Accounts

    Username: Admin
    Password: Admin!12345
    Role: Admin
    Details: Account with administrative functions. Ability to add/remove courses, add/remove, questions, add/remove events
    
    Username: User1
    Password: User1!12345
    Role: Regular User
    Details: Simulated Experience of an Average User
    
    Username: User2
    Password: User2!12345
    Role: Regular User
    Details: Simulated Experience of an Average User
    
    Username: User3
    Password: User3!12345
    Role: Regular User
    Details: Simulated Experience of an Average User


Features Demonstrated

    1. Course Enrollment
    - After the admin has loaded select courses from the management system (Pulled from the SFU API; We have preloaded a couple CMPT courses already to show the functionality)
      end users are able enroll themselves into the courses.
    - When enrolled, the user can view the message boards, use the live chat system, create study groups or create sample quizzes for others enrolled in the courses
    
    2. Message Board
    - For each course, we have discussion forums capable of nested discussion and replies.
    - Each reply will display the user's response to the layer above.
    - The reply also has the ability to have an uploaded file to show the file.
    - This currently works best with images and will automatically be loaded with the response.
    
    3. Live Chat System
    - Rather than only having a discussion and message board, we have implemented a live chat system for quick interactions between students.
    - Each course page has their individual live chat system and the users can chat with one another about course material.
    - For guests who don't have accounts, they can create a guest username and chat along with users.
    
    4. Study Groups
    - Within the course and the users who have enrolled in the course, users are able to create a study group for the course. This can be used to help facilitate events and make it easier to connect with other students
    - In the group, you can automatically invite other students to join. 
    
    5. Sample Quizzes
    - For each course, users have the ability to create quizzes or take quizzes that were created by their peers. 
    The quizzes are multiple choice and can be used to test the quiz creator's application of knowledge as well as other users ability to recall course information.
    - Their scores are dispalyed without answers to encourage interaction between the creator and the quiz taker. This will help facilitate students to find interactive ways to study with one another and discuss course material.
    - Quizzes can be time-sensitive and can be locked by an 'expiration date' so it can only be entered prior to the end date/time.
    
    6. Events 
    - When a user creates an event, he can choose one of two ways of doing it. If done through the event tab, you will create a base event for a course which will be displayed globally.
      The intention of this is for anyone who is available to be able to see the event and RSVP.
    - The second way of creating events is through your study group. Through this, the event will automatically invite all the members of the group.
    - Both methods will have a notification system that sends a reminder email for the event.
    
    
Archived ReadMe from past iterations
    
    Asp.net MVC5(Model, View, Controller) Framework:
    ·        Account System (Implemented by the framework)
    ·        Improved account system
    ·        Custom role for account and admin page for admin role.
    ·        By entering the key of admin role "000000", user can register as an admin. 
    ·        Razor syntax(view)
    ·        The communication between server and client(controller)
    ·        Database initiate and migration(model)
    ·        The page to add data and show data
    Asp.net MVC with React
    Asp.net Signal IR
    
    Simple API for two-way client/server communication
    The live chat function present in the contact page
    Open two same web page.
    User1 input the user name and type in the message in one page
    The message will display on both client side web page and its send time too
    The user2 can type message and sent to user1’s webpage
    
    Deplyment:
    Our deployment only can show one type of model at the same time.
    And it is not a hot workstation.
    
    It is deployed to c9.io.
    Deployment URL:http://blank-osk666.c9users.io/
    Username: osk666@gmail.com
    Password: Cmpt470team16
    Workstation: blank
    
    Steps to deploy a specific model:
    
    Start service:
    1.Enter command "sudo service nginx restart"
    2.Enter command "sudo service mysql restart"
    
    Asp.net Web Page:
    1.Go to /workspace/c470/cmpt470project/RazorWebpages
    2.Enter command "dotnet run"
    MVC5:
    1.Go to /workspace/c470/cmpt470project/mvc2
    2.Enter command "dotnet run"
    Asp.net MVC with React:
    1.Go to /workspace/c470/cmpt470project/mvc5
    2.Enter command "dotnet run"
    Asp.net Signal IR:
    1.Go to /workspace/c470/cmpt470project/mvc_SIGNALR_DEMO
    2.Enter command "dotnet run"
    
    Steps for running the final project server:
    1.Go to /workspace/c470/cmpt470project/FinalProject
    2.Enter command "dotnet run"
    
    Steps for setting up database in your virtual machine:
    1. mysql -u root -p
    2. GRANT ALL PRIVILEGES ON *.* TO 'team16'@'localhost' IDENTIFIED BY 'password';
    3. quit
    4. sudo service mysql restart
     
     Steps for setting up in your virtual machine:
    1. curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
    2. sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
    3. sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
    4. sudo apt-get install apt-transport-https
    5. sudo apt-get update
    6. sudo apt-get install dotnet-sdk-2.1.4
    7. git clone git@csil-git1.cs.surrey.sfu.ca:yuzhip/CMPT470_Project.git
    8. cd FinalProject
    9. dotnet restore
    10. dotnet ef database update
    11. dotnet run
     
    PS: Our deployment only can show one type of model at the same time.