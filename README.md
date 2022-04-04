1. Vi vill kunna få ut en lista med alla anställda i systemet. 
https://localhost:5001/api/Employee


2. Vi vill kunna hämta ut detaljerad information om en specifik anställd och dennas tidsrapporter. 
https://localhost:5001/api/timereport/getempwithtimereport/1


3. Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt.
https://localhost:5001/api/timereport/getprojectwithemp/4


4. Vi vill kunna få ut många timmar en specifik anställd jobbat en specifik vecka (ex antal timmar vecka 25)
https://localhost:5001/api/timereport/getemptimespecweek/5/13


5. Vi vill kunna lägga till, uppdatera och ta bort anställda.
[HTTPPOST] {"fName": "", "lName": "", "title": ""}
[HTTPPUT]{id}  {"fName": "", "lName": "", "title": ""}
[HTTPDELETE]{id}


6. Vi vill kunna lägga till, uppdatera och ta bort projekt
[HTTPPOST] {"ProjectName": ""}
[HTTPPUT]{id}  {"ProjectName": ""}
[HTTPDELETE]{id}

7. Vi vill kunna lägga till, uppdatera och ta bort specifika tidsrapporter
[HTTPPOST] {"hoursWorked": , "weekNumber": , "employee": null, "employeeId": , "project": null, "projetId": }
[HTTPPUT]{id} {"hoursWorked": , "weekNumber": , "employee": null, "employeeId": , "project": null, "projetId": }
[HTTPDELETE]{id}




