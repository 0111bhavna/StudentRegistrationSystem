$(function () {
    GetStatus();
});

function GetStatus(){

    getData().then((response) => {
        if (response) {
            console.log(response);
            summaryTable(response);
        }
        
    }).catch((error) => {
        console.error(error);
        toastr.error('');
    });
}

function getData(){

    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Admin/AssignStatus",
            data: null,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });

}
function summaryTable(studentSummary) {
    var table = $("table#StudentTable");
    var tbody = "";
    if (studentSummary) {
        for (var indexStudent = 0; indexStudent < studentSummary.length; indexStudent++) {
            let numResults = studentSummary[indexStudent].Results.length;
            for (var index = 0; index < numResults; index++) {
                let result = studentSummary[indexStudent].Results[index];
                if (index == 0) {
                    tbody += `<tr>
                            
                            <td rowspan="${numResults}">${studentSummary[indexStudent].FirstName}</td>
                            <td rowspan="${numResults}">${studentSummary[indexStudent].Surname}</td>
                            <td> ${result.Subject.SubjectName}</td >
                            <td> ${result.Grade.GradeName}</td>

                            <td rowspan="${numResults}">${studentSummary[indexStudent].TotalScore}</td>
                            <td rowspan="${numResults}">${studentSummary[indexStudent].Status}</td>
                            </tr>`;
                }
                else {
                    
                    tbody += `<tr>
                              <td> ${result.Subject.SubjectName}</td >
                              <td>${result.Grade.GradeName}</td>
                              </tr>`;
                }
            }
        }
    }
    else {
        tbody = "<tr colspan='7'>No students found</tr>";
    }
    table.append(tbody);
}


