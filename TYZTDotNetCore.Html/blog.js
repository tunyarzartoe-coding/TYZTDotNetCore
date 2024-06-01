const tblBlog = "blog";

// readBlog();
// createBlog();
//updateBlog("541dbd99-a0a6-4a58-b9e2-723a13d1ea44","updated","updated","updated")
//deleteBlog("541dbd99-a0a6-4a58-b9e2-723a13d1ea44")

function readBlog() {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);
}

function createBlog() {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);

  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  const requestModal = {
    id: uuidv4(),
    title: "Test Title",
    author: "Test Author",
    content: "Test Content",
  };

  lst.push(requestModal);

  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage("Saving Successful.");
  clearControls();
}

function updateBlog(id, title, author, content) {
  const blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

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

function deleteBlog(id) {
  const blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }

  const items = lst.filter((x) => x.id === id);
  console.log("items ====>", items);
  console.log(items.length);

  if (items.length == 0) {
    console.log("no data found.");
    errorMessage("no data found.");
    return;
  }

  lst = lst.filter((x) => x.id !== id);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}
