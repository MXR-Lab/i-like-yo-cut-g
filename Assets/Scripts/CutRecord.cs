using System.Collections;
using System.Collections.Generic;


public class CutRecord
{
    private string cutName;
    private List<float> testErrors;
    private List<float> teachErrors;

    public CutRecord(string name)
    {
        cutName = name;
        testErrors = new List<float>();
        teachErrors = new List<float>();
    }

    public void addTestError(float error)
    {
        testErrors.Add(error);
    }

    public void addTeachError(float error)
    {
        teachErrors.Add(error);
    }

    public string getName()
    {
        return cutName;
    }

    public List<float> getTestErrors()
    {
        return testErrors;
    }

    public List<float> getTeachError()
    {
        return teachErrors;
    }

}
