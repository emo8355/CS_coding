using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;


//Build a grading system for assignments using C# with OO design. 
//The system has a simple menu to enter commands and data and show the results. 
//The System can start with a static list of students (student name, id) 
//and a static list of assignments( Assignment number, Assignment name, weight),
//then you can enter the grades from each assignmeent for each student from the console. 
//After that, you can ask the system to show the results as explained in point 3.

//1.Draw UML Class diagram for your classes (2 marks)

//2.Implement your classes according to OOP and code reusability principles (3 marks) done

//3.Build a CLI menu from which you can send commands to your grading system. 
//  From the menu you can choose entering grades for a certain assignment, 
//  print average grade per assignment, print average grade per student, 
//  print students names and grades in a descending order based on the 
//  student’s average grade in all assignments. (3 marks)

//4.Your system should be working correctly with no mistakes (2 marks) half done


namespace Lab_3
{
    class lab_3
    {
        
        const string menu = @"======================================================
        1. Show all Student
        2. show all assignment
        3. Grade a assignment 
        4. Show average grade of a certain student
        5. Show average grade of a assignment
        6. Add a new student
        7. Add a new assignment
        e. Exit the program 
======================================================
Enter your options: ";

        static ArrayList assignmentList =new ArrayList {
            new { name = "ass_1", weight = 5 },
            new { name = "ass_2", weight = 5 },
            new { name = "ass_3", weight = 5 },
            new { name = "ass_4", weight = 5 }
        };

        static Student Student1 = new Student(name: "Skylar", id: 1, allAssignment: assignmentList);
        static Student Student2 = new Student(name: "Cindy", id: 2, allAssignment: assignmentList);
        static Student Student3 = new Student(name: "Jeff", id: 3, allAssignment: assignmentList);
        static ArrayList StudentList = new ArrayList{ Student1, Student2, Student3 };

        static void Main(string[] args)
        {
            userControl();
        }

        static void showAllStudent()
        {
            foreach (Student item in StudentList)
            {
                Console.WriteLine(item.studentInfoGetter());
            }

        }

        static void showAllAssignment()
        {
            foreach (object item in assignmentList)
            {
                Console.WriteLine($"Assignment Info: {item}");
            }
        }

        static void changeStudentGrade(int studentID, int assignmentNumber, double grade)
        {
            foreach (Student s in StudentList)
            {
                if (s.StudentId == studentID)
                {
                    foreach (Assignment a in s.assignmentList)
                    {
                        if (a.AssignmentNumber == assignmentNumber)
                        {
                            a.AssignmentGrade = grade;
                            //Console.WriteLine(a.AssignmentGrade);
                        }
                    }
                }
            }
        }

        static void gradeAssignment()
        {
            Console.WriteLine("Which student(by student number): ");
            int studentNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Which assignment(by assignment number) :");
            int assignmentNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marks: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            changeStudentGrade(studentNumber, assignmentNumber, grade);
            bool x = true;
            while (x)
            {
                Console.WriteLine("Do you want to keep grading this student? (t or f)");
                string isGrading = Console.ReadLine();
                if (isGrading == "t")
                {
                    Console.WriteLine("Which assignment(by assignment number) :");
                    assignmentNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Marks: ");
                    grade = Convert.ToDouble(Console.ReadLine());
                    changeStudentGrade(studentNumber, assignmentNumber, grade);

                } else {

                    x = false;

                }
            }
        }

        static void calculateAvgOfOneStudent()
        {
            double sum = 0;
            int totalAssignment = 0;
            Console.WriteLine("Which student(by student number): ");
            int studentNumber = Convert.ToInt32(Console.ReadLine());
            foreach (Student s in StudentList)
            {
                if (s.StudentId == studentNumber)
                {
                    foreach (Assignment a in s.assignmentList)
                    {
                        Console.WriteLine($"student{s.StudentId} assignment: {a.AssignmentNumber} marks: { a.AssignmentGrade}");
                        totalAssignment = s.assignmentList.Count;
                        sum += a.AssignmentGrade;

                    }
                }
            }
            Console.WriteLine($"Average of student{studentNumber} : {sum / Convert.ToDouble(totalAssignment) }");
        }

        static void calculateAvg()
        {
            double sum = 0;
            int totalStudent = 0;
            Console.WriteLine("Which assignment you want to know ? ");
            int assignmentId = Convert.ToInt32(Console.ReadLine());
            foreach (Student s in StudentList)
            {
                totalStudent = StudentList.Count;
                foreach(Assignment a in s.assignmentList)
                {
                    if (a.AssignmentNumber == assignmentId)
                    {
                        sum += a.AssignmentGrade;
                    }
                }
            }

            Console.WriteLine($"Average of Assignment {assignmentId} : {sum / Convert.ToDouble(totalStudent) }");
        }

        static void createNewStudent()
        {
            Console.WriteLine("What is the student's name: ");
            string newStudentName = Console.ReadLine();

            Student newStudent = new Student(name: newStudentName, id: StudentList.Count + 1, allAssignment: assignmentList);

            StudentList.Add(newStudent);
            Console.WriteLine($"New student is being added \n Student name: {newStudentName} \n Student id: {StudentList.Count} \n");
        }

        static void createNewAssignment()
        {
            Console.WriteLine("Assignment name: ");
            string name = Console.ReadLine();
            Console.WriteLine("How much it weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            foreach (Student s in StudentList)
            {
                s.creatNewAssignment(name, weight);
            }
            assignmentList.Add(new { name = name, weight = weight });
            Console.WriteLine($"New Assignment created \n Name: {name} \n assignment weight: {weight}");
        }


        static void userControl()
        {
            bool x = false;
            do
            {
                Console.WriteLine(menu);
                string userOption = Console.ReadLine();
                switch (userOption)
                {
                    case "1":
                        showAllStudent();
                        break;

                    case "2":
                        showAllAssignment();
                        break;
                    case "3":
                        gradeAssignment();
                        break;
                    case "4":
                        //show avg of student
                        calculateAvgOfOneStudent();
                        break;
                    case "5":
                        //show avg of assignment
                        calculateAvg();
                        break;
                    case "6":
                        //add student
                        createNewStudent();
                        break;
                    case "7":
                        //add assignement
                        createNewAssignment();
                        break;
                    case "e":
                        x = true;
                        break;

                }
            }
            while (!x);


        }


    }


}
