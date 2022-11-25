//Students sanj = new(1, "Sanjit", "Poudel", "11-11-2000");

Teachers UnNamed = new("Unkown", "Unkown", "Unkown", "11-11-2000");
Teachers Niels = new("Teacher", "Niels", "Olesen", "23-02-1971");
Teachers Peter = new("Teacher", "Peter", "Lindenskov", "01-01-1970");
Teachers Jan = new("Teacher", "Jan", "Johansen", "01-01-1970");
Teachers Henrik = new("Teacher", "Henrik", "Poulsen", "01-01-1975");

Course Unkown = new(CourseEnum.Unkown.ToString(), UnNamed);
Course ClientSide = new(CourseEnum.Clientsideprogrammering.ToString(), Peter);
Course StudieTeknik = new(CourseEnum.Studieteknik.ToString(), Niels);
Course GrundlProg = new(CourseEnum.Grundlæggendeprogrammering.ToString(), Niels);
Course OOP = new(CourseEnum.OOP.ToString(), Niels);
Course Database = new(CourseEnum.Databaseprogrammering.ToString(), Niels);
Course Computerteknologi = new(CourseEnum.Computerteknologi.ToString(), Jan);
Course Netværk = new(CourseEnum.Netværk.ToString(), Henrik);

List<Course> courseList = new List<Course>();
courseList.Add(Unkown);
courseList.Add(ClientSide);
courseList.Add(StudieTeknik);
courseList.Add(GrundlProg);
courseList.Add(OOP);
courseList.Add(Database);
courseList.Add(Computerteknologi);
courseList.Add(Netværk);
// TODO add all course object


// dictionary that store course enum and its index
Dictionary<CourseEnum, int> courseEnumDict = new Dictionary<CourseEnum, int>()
{
    {CourseEnum.Unkown, (int)CourseEnum.Unkown },
    {CourseEnum.Clientsideprogrammering, (int)CourseEnum.Clientsideprogrammering},
    {CourseEnum.Studieteknik, (int)CourseEnum.Studieteknik },
    {CourseEnum.Grundlæggendeprogrammering, (int)CourseEnum.Grundlæggendeprogrammering },
    {CourseEnum.OOP, (int)CourseEnum.OOP},
    {CourseEnum.Databaseprogrammering, (int)CourseEnum.Databaseprogrammering},
    {CourseEnum.Computerteknologi, (int)CourseEnum.Computerteknologi},
    {CourseEnum.Netværk, (int)CourseEnum.Netværk }
};
//------------------------------ TEmp Test -------------------------------------
/*
string conCourse = "oop";
Temp temp1;
//check if input course is in enum list, ignoring case
if(Enum.TryParse<Temp>(conCourse, true, out temp1))
{
    Console.WriteLine("{0} converted to {1}", conCourse, temp1);
    int courseIndex = courseEnumDict.GetValueOrDefault(temp1);  
    Course testCourse = courseList[courseIndex];
    List<Enrollment> _enrollmentList2 = new List<Enrollment>();
    _enrollmentList2.Add(new Enrollment(sanj, testCourse));

    foreach (var item in _enrollmentList2)
    {
        Console.WriteLine($"{item.StudentInfo.FirstName} {item.StudentInfo.LastName}  Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName} ");
    }

}
*/
//temp1 = Enum.Parse<temp>(conCourse, out temp1);

//int courseIndex = (int)Temp.OOP;
/*
Course testCourse = courseList[cind];
List<Enrollment> _enrollmentList2 = new List<Enrollment>();
_enrollmentList2.Add(new Enrollment(sanj, testCourse));

foreach (var item in _enrollmentList2)
{
    Console.WriteLine($"{item.StudentInfo.FirstName} {item.StudentInfo.LastName}  Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName} ");
}
*/
//-----------------------------------------------------------------------
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
                    Console.WriteLine(courseEnum);
                }
            }

            Students student = new(studentID, firstName, lastName, dateOfBirth);
          

            Console.WriteLine("----------------------------------------------------");
            course = Console.ReadLine().ToUpper();
            CourseEnum _courseEnum;
            //check if input course is in enum list, ignoring case
            if (Enum.TryParse<CourseEnum>(course, true, out _courseEnum))
            {
                //Console.WriteLine("{0} converted to {1}", course, _courseEnum);
                int courseIndex = courseEnumDict.GetValueOrDefault(_courseEnum);
                Course courses = courseList[courseIndex];
                List<Enrollment> _enrollmentList2 = new List<Enrollment>();
                _enrollmentList2.Add(new Enrollment(student, courses));

                foreach (var item in _enrollmentList2)
                {
                    Console.WriteLine($"\n{item.StudentInfo.FirstName} {item.StudentInfo.LastName}  {item.StudentInfo.Age} Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName} \n");
                }

            }
            else
            {
                Console.WriteLine("Error: Course Not found. Try again");
            }

            //Outdated
            /*
            
            if(CourseEnum.Clientsideprogrammering.ToString().ToUpper() == course)
            {
                _enrollmentList.EnrollList.Add(new Enrollment(student, ClientSide));
            }

            else if (CourseEnum.Studieteknik.ToString().ToUpper() == course)
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
            */
        }
    }

    else
    {
        Console.WriteLine("Wrong Choice My lad");
    }
}