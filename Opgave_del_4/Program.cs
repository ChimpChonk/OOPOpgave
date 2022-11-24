Teachers Niels = new("Teacher", "Niels", "Olesen", "23-02-1971");
Teachers Peter = new("Teacher", "Peter", "Lindenskov", "01-01-1970");
Teachers Jan = new("Teacher", "Jan", "Johansen", "01-01-1970");
Teachers Henrik = new("Teacher", "Henrik", "Poulsen", "01-01-1975");

Course ClientSide = new(CourseEnum.Clientsideprogrammering.ToString(), Peter);
Course StudieTeknik = new(CourseEnum.Studieteknik.ToString(), Niels);
Course GrundlProg = new(CourseEnum.Grundlæggendeprogrammering.ToString(), Niels);
Course OOP = new(CourseEnum.OOP.ToString(), Niels);
Course Database = new(CourseEnum.Databaseprogrammering.ToString(), Niels);
Course Computerteknologi = new(CourseEnum.Computerteknologi.ToString(), Jan);
Course Netværk = new(CourseEnum.Netværk.ToString(), Henrik);


Enrollment _enrollmentList = new();

_enrollmentList.EnrollList = new();


bool menuLoop = true;

string? firstName;
string? lastName;
string? dateOfBirth;
string? course;

/*
 ------------------------------------------------------------------------------
                            Menu
 ------------------------------------------------------------------------------
 */
while (menuLoop)
{
    Console.WriteLine("1) Add a student to a Course:");

    string? userInput = Console.ReadLine();


    if (userInput == "1")
    {
        Console.Clear();
        Console.Write("Give Student ID: ");
        bool success = int.TryParse(Console.ReadLine(), out int studentID);
        if (!success)
        {
            Console.WriteLine("Error: Write a number not a letter.");
        }
        while (success)
        {


            Console.Write("Student First Name: ");
            firstName = Console.ReadLine();

            Console.Write("Student Last Name: ");
            lastName = Console.ReadLine();

            Console.Write("Student Date of Birth (dd-mm-yyyy): ");
            //dateOfBirth.
            dateOfBirth = Console.ReadLine();

            Console.WriteLine("Choose Course: \n----------------------------------------------------");
            foreach (CourseEnum courseEnum in Enum.GetValues(typeof(CourseEnum)))
            {
                string courseEnums = courseEnum.ToString();
                if (courseEnums != "Unkown")
                {
                    Console.WriteLine(courseEnum);+
                }
            }

            Students student = new(studentID, firstName, lastName, dateOfBirth);
          

            Console.WriteLine("----------------------------------------------------");
            course = Console.ReadLine().ToUpper();
            
            if(CourseEnum.Clientsideprogrammering.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, ClientSide));
            }

            else if (CourseEnum.Studieteknik.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, StudieTeknik));
            }

            else if (CourseEnum.Grundlæggendeprogrammering.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, GrundlProg));
            }

            else if (CourseEnum.OOP.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, OOP));
            }

            else if (CourseEnum.Databaseprogrammering.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, Database));
            }

            else if (CourseEnum.Computerteknologi.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, Computerteknologi));
            }

            else if (CourseEnum.Netværk.ToString() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, Netværk));
            }

            else
            {
                Console.WriteLine("Error: Course Not found. Try again");
            }

            foreach (var item in _enrollmentList.EnrollList)
            {
                Console.WriteLine($"\n{item.StudentInfo.FirstName} {item.StudentInfo.LastName} Age: {item.StudentInfo.Age}  Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName}.\n");
            }
        }
    }

    else
    {
        Console.WriteLine("Wrong Choice My lad");
    }
}