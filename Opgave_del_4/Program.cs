bool menuLoop = true;

int studentID;
string firstName;
string lastName;
string dateOfBirth;
string course;

/*
 ------------------------------------------------------------------------------
                            Menu
 ------------------------------------------------------------------------------
 */
while(menuLoop)
{
    Console.WriteLine("1) Add a student to a Course:\n");

    string? userInput = Console.ReadLine();

    Choice _choice = new(userInput);

    if(_choice.UserChoice == ChoiceEnum.AddStudent)
    {
    }
}


void AddStudent()
{
    Console.Write("Give Student ID: ");
}