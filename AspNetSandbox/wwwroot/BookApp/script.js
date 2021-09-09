const form = document.getElementById("formm");


function insertNewRow(obj) {
    var table = document.getElementsByTagName("table")[0];

    var newRow = table.insertRow(table.rows.length);

    var cel1 = newRow.insertCell(0);
    var cel2 = newRow.insertCell(1);
    var cel3 = newRow.insertCell(2);
    var cel4 = newRow.insertCell(3);
    var cel5 = newRow.insertCell(4);
    var cel6 = newRow.insertCell(5);
    var cel7 = newRow.insertCell(6);
    var cel8 = newRow.insertCell(7);

    cel1.innerHTML = obj.fname;
    cel2.innerHTML = obj.lname;
    empImg = document.createElement("img");
    empImg.src = obj.photo;
    cel3.appendChild(empImg);
    cel4.innerHTML = obj.email;
    cel5.innerHTML = obj.sex;
    cel6.innerHTML = obj.bday;
    cel7.innerHTML =
        '<input type="button" value="Delete" onclick="deleteRow(this,\'' +
        obj.id +
        "')\" />";
    cel8.innerHTML =
        '<button type="button" onclick="editRow(this,\'' +
        obj.id +
        "')\">Edit</button>";

    document.getElementById("formm").reset();
}

function addRow() {
    // get input values
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var email = document.getElementById("email").value;
    var sex = document.getElementById("sex").value;
    var bday = document.getElementById("bday").value;

    var obj = new Object();
    obj.fname = fname;
    obj.lname = lname;
    obj.email = email;
    obj.photo = preview;
    obj.sex = sex;
    obj.bday = bday;
    obj.id = getRandomIntInclusive().toString();

    // store to firestore
    db.collection("users").doc(obj.id).set(obj);

    // add new row
    insertNewRow(obj);
    return false;
}
function deleteRow(r, id) {
    var i = r.parentNode.parentNode.rowIndex;
    document.getElementById("tabell").deleteRow(i);

    db.collection("users").doc(id).delete();
}

function myFunction() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabell");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// load more docs (button)
const loadMore = document.querySelector(".loadmore button");

const handleClick = () => {
    first(latestDoc);
};

loadMore.addEventListener("click", handleClick);
cancel.addEventListener("submit", cancelChange);
