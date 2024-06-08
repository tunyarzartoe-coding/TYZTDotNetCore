const tblBlog = "blog";
let blogId = null;

getBlogTable();
// testConfirmMessage();
// testConfirmMessage2();

function testConfirmMessage() {
  let confirmMessage = new Promise(function (success, error) {
    const result = confirm("Are you sure want to delete?");
    if (result) {
      success();
    } else {
      error();
    }
  });

  confirmMessage.then(
    function (value) {
      successMessage("Success");
    },
    function (error) {
      errorMessage("Error");
    }
  );
}

// readBlog();
// createBlog();
//updateBlog("541dbd99-a0a6-4a58-b9e2-723a13d1ea44","updated","updated","updated")
//deleteBlog("541dbd99-a0a6-4a58-b9e2-723a13d1ea44")

function readBlog() {
  let lst = getBlogs();
  console.log(lst);
}

function editBlog(id) {
  let lst = getBlogs();

  const items = lst.filter((x) => x.id === id);
  console.log(items);

  console.log(items.length);

  if (items.length == 0) {
    console.log("no data found.");
    errorMessage("no data found.");
    return;
  }

  let item = items[0];

  blogId = item.id;
  $("#txtTitle").val(item.title);
  $("#txtAuthor").val(item.author);
  $("#txtContent").val(item.content);
  $("#txtTitle").focus();
}

function createBlog(title, author, content) {
  let lst = getBlogs();

  const requestModal = {
    id: uuidv4(),
    title: title,
    author: author,
    content: content,
  };

  lst.push(requestModal);

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage("Saving Successful.");
  clearControls();
}

function updateBlog(id, title, author, content) {
  let lst = getBlogs();

  const items = lst.filter((x) => x.id === id);
  console.log("items ====>", items);
  console.log(items.length);

  if (items.length == 0) {
    console.log("no data found.");
    errorMessage("no data found.");
    return;
  }

  const item = items[0];
  item.title = title;
  item.author = author;
  item.content = content;

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage("Updating Successful.");
}

// function deleteBlog2(id) {
//   let result = confirm("are you sure want to delete?");
//   if (!result) return;

//   let lst = getBlogs();

//   const items = lst.filter((x) => x.id === id);
//   if (items.length == 0) {
//     console.log("no data found.");
//     return;
//   }

//   lst = lst.filter((x) => x.id !== id);
//   const jsonBlog = JSON.stringify(lst);
//   localStorage.setItem(tblBlog, jsonBlog);

//   successMessage("Deleting Successful.");

//   getBlogTable();
// }

// function deleteBlog(id) {
//   Swal.fire({
//     title: "Confirm",
//     text: "Are you sure want to delete?",
//     icon: "warning",
//     showCancelButton: true,
//     confirmButtonText: "Yes",
//   }).then((result) => {
//     if (!result.isConfirmed) return;
//     let lst = getBlogs();

//     const items = lst.filter((x) => x.id === id);
//     if (items.length == 0) {
//       console.log("no data found.");
//       return;
//     }

//     lst = lst.filter((x) => x.id !== id);
//     const jsonBlog = JSON.stringify(lst);
//     localStorage.setItem(tblBlog, jsonBlog);

//     successNotifyMessage("Product successfully deleted!");

//     getBlogTable();
//   });
// }

// delete with customConfirmMessage
function deleteBlog(id) {
  confirmMessage("Are you sure want to delete").then(function (value) {
    let lst = getBlogs();

    const items = lst.filter((x) => x.id === id);
    if (items.length == 0) {
      console.log("no data found.");
      return;
    }

    lst = lst.filter((x) => x.id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successNotifyMessage("Product successfully deleted!");

    getBlogTable();
  });
}

function getBlogs() {
  const blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  return lst;
}

$("#btnSave").click(function () {
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();
  if (!title || !author || !content) {
    Notiflix.Notify.failure("Please enter title,author and content.");
    return false;
  }
  if (blogId === null) {
    createBlog(title, author, content);
  } else {
    updateBlog(blogId, title, author, content);
    blogId = null;
  }

  getBlogTable();
});

function clearControls() {
  $("#txtTitle").val("");
  $("#txtAuthor").val("");
  $("#txtContent").val("");
  $("#txtTitle").focus();
}

function getBlogTable() {
  const lst = getBlogs();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="editBlog('${
                  item.id
                }')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteBlog('${
                  item.id
                }')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
        `;
    htmlRows += htmlRow;
  });

  $("#tbody").html(htmlRows);
}
