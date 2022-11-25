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

Enrollment _enrollList = new();
_enrollList.EnrollList = new List<Enrollment>();

//Enrollment _enrollList = new Enrollment();
//List<Enrollment> _enrollmentList = new List<Enrollment>();

bool menuLoop = false;

string? firstName;
string? lastName;
string? dateOfBirth;
string? course;
string? addCourses;
bool moreCourses = false;
string? addStudent;
bool success = false;
int studentID;
bool inputCheck = true;

/*
 ------------------------------------------------------------------------------
                            Menu
 ------------------------------------------------------------------------------
 */
do
{
    while(inputCheck)
    {
        Console.WriteLine("1) Add a student to a Course");
        Console.Write("\nChoose 1: ");

        string? userInput = Console.ReadLine();
        if (userInput != "1")
        {
            Console.WriteLine("Please choose one of the Options.");
            Console.ReadKey();
            Console.Clear();
        }

        else
            inputCheck = false;

    }
    do
    {

        Console.Clear();
        Console.Write("Give Student ID: ");
        success = int.TryParse(Console.ReadLine(), out studentID);
        if (!success)
        {
            Console.WriteLine("Error: Write a number not a letter.");
            Console.ReadKey();
        }
    }
    while (!success);


    Console.Write("Student First Name: ");
    firstName = Console.ReadLine();

    Console.Write("Student Last Name: ");
    lastName = Console.ReadLine();

    Console.Write("Student Date of Birth (dd-mm-yyyy): ");
    dateOfBirth = Console.ReadLine();
    if(dateOfBirth != DateTime.ParseExact(dateOfBirth, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString())
    {
        Console.WriteLine("Wrong date Format");
    }
    Students student = new(studentID, firstName, lastName, dateOfBirth);

    do
    {
        Console.WriteLine("Choose Course: \n----------------------------------------------------");
        foreach (CourseEnum courseEnum in Enum.GetValues(typeof(CourseEnum)))
        {
            string courseEnums = courseEnum.ToString();
            if (courseEnums != "Unkown")
            {
                Console.WriteLine(courseEnum);
            }
        }

        Console.WriteLine("----------------------------------------------------");
        course = Console.ReadLine();
        Console.WriteLine();
        CourseEnum _courseEnum;
        //check if input course is in enum list, ignoring case
        if (Enum.TryParse<CourseEnum>(course, true, out _courseEnum))
        {
            //Console.WriteLine("{0} converted to {1}", course, _courseEnum);
            int courseIndex = courseEnumDict.GetValueOrDefault(_courseEnum);
            Course courses = courseList[courseIndex];
            _enrollList.EnrollList.Add(new Enrollment(student, courses));

            _enrollList.EnrollList.Sort();
            foreach (var item in _enrollList.EnrollList)
            {
                Console.WriteLine($"{item.StudentInfo.FirstName} {item.StudentInfo.LastName} Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName}");
            }

            try
            {
                courses.CourseStudentAmount(courses.StudentList(_enrollList));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        else
        {
            Console.WriteLine("Wrong Choice My lad. Press any Key to try again");
            Console.ReadLine();
            break;
        }

        Console.WriteLine("Press 1 to add more courses. Press any other key to exit");
        addCourses = Console.ReadLine();
        if (addCourses != "1")
        {
            moreCourses = false;
        }
        else
            Console.Clear();
    }
    while (!moreCourses);

    Console.WriteLine("Press 1 to add Student or Any press any other keys to exit");
    addStudent = Console.ReadLine();
    Console.Clear();
    if (addStudent != "1")
    {
        menuLoop = true;
    }

}
while (!menuLoop);

foreach (var item in _enrollList.EnrollList)
{
    Console.WriteLine($"{item.StudentInfo.FirstName} {item.StudentInfo.LastName} Age: {item.StudentInfo.Age}  Course: {item.CoursesInfo.CourseName}  Teacher: {item.CoursesInfo.Teachers.FirstName} {item.CoursesInfo.Teachers.LastName}.");
}

Console.WriteLine("Press enter to exit");