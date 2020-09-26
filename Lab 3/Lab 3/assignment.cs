using System;

public class Assignment
{
    private int assignmentNumber;
    private string AssignmentName;
    private double AssignmentWeight;
    private double assignmentGrade;
    
    public int AssignmentNumber
    {
        get { return this.assignmentNumber; }
        set { this.assignmentNumber = value; }
    }
    
    public double AssignmentGrade
    {
        get { return this.assignmentGrade; }
        set { this.assignmentGrade = value; }
    }

	public Assignment(){}
    public Assignment(int number, string name, double weight)
    {
        this.AssignmentNumber = number;
        this.AssignmentName = name;
        this.AssignmentWeight = weight;
        this.AssignmentGrade = 0;
    }


    public string AssignmentGetter()
    {
        return ($"Assignment Info:\n  Assignment number is: {this.AssignmentNumber} \n    Assignment name is: {this.AssignmentName} \n    Assignment weight is: {this.AssignmentWeight}\n");
    }

    
}
