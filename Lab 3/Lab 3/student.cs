using System;
using System.Collections;
using System.Globalization;

public class Student
{

	private string studentName;
	private int studentId;
	public ArrayList assignmentList;


	public int StudentId
    {
        get { return this.studentId; }
		set { this.studentId = value; }
    }

	
	// The default constructor has no parameters. The default constructor
	// is invoked in the processing of object initializers.
	// You can test this by changing the access modifier from public to
	// private. The declarations in Main that use object initializers will
	// fail.

	public Student(){}
	public Student(string name, int id , ArrayList allAssignment)
    {
		studentName = name;	
		studentId =  id;

		assignmentList = new ArrayList();

		foreach (object item in allAssignment)
        {
			double weightOfAssignment = Convert.ToDouble(item.GetType().GetProperty("weight").GetValue(item, null));
			string assignmentName = Convert.ToString(item.GetType().GetProperty("name").GetValue(item, null));
            assignmentList.Add(new Assignment(number: assignmentList.Count + 1, name: assignmentName, weight: weightOfAssignment));
		}

	}

	public void creatNewAssignment(string assignmentName, double weight )
    {
		assignmentList.Add(new Assignment(number: assignmentList.Count + 1 , name: assignmentName, weight: weight)) ;
	}

	public string studentInfoGetter()
    {
		return ($"Student Info:\n	Student name: {this.studentName} \n	Student Id: {this.studentId} \n");
    }
}
