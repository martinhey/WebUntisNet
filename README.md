# WebUntisNet

## Build status

![Build status](https://travis-ci.org/martinhey/WebUntisNet.svg?branch=master)

This is an API client to access Webuntis. It is written as .NET Standard library to be used in .NET Framework projects and .NET Core projects as well. 

## Usage

### Connect to your WebUntis instance

WebUntisClient is the main entry point for you to use this library. The constructor needs several parameters which are mandantory to connect to your WebUntis instance. You don't have to deal with authentication and session handling. It's all done by this library. 

```
using(var client = new WebUntisClient("https://my.webuntis.local/WebUntis/jsonrpc.do", "schoolname", "user", "password"))
{
    var timetable = await client.GetTimetableAsync(ElementType.Student, 1497);
    ....
}
```

### Supported functions

* GetTeachersAsync (Ref. 3)
* GetStudentsAsync (Ref. 4)
* GetClassesAsync (Ref. 5)
* GetSubjectsAsync (Ref. 6)
* GetRoomsAsync (Ref. 7)
* GetDepartmentsAsync (Ref. 8)
* GetHolidaysAsync (Ref. 9)
* GetTimegridAsync (Ref. 10)
* GetStatusDataAsync (Ref. 11)
* GetCurrentSchoolYearAsync (Ref. 12)
* GetSchoolYearsAsync (Ref. 13)
* GetTimetableAsync (Ref. 14)
* GetLatestImportTimeAsync (Ref. 17)
* GetPersonIdAsync (Ref. 18)
* GetClassRegEvents (Ref. 20)
* GetExamsAsync (Ref. 21)
* GetExamTypesAsync (Ref. 22, not tested)

### Functions under development

* Request timetable for an element (customizable) (Ref. 15)
* Request substitutions (Ref. 19)


## Contribution

As Untis provides minimal support for it's API and the quality of their API documentation is not as good as it could be, I'd be happy to find someone to contribute or to provide a demo access to WebUntis. I tested the calls using the official instance, but the public users don't have suficcient rights for all actions.
