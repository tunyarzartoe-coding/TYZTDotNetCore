$(document).ready(function () {
  const tblProducts = "products";

  getProducts();

  function getProducts() {
    const products = JSON.parse(localStorage.getItem(tblProducts)) || [];
    let productCardsContainer = $("#productCards");
    productCardsContainer.empty();
    products.forEach((product) => {
      let productCard = `
                <div class="col-md-3 mb-4">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">${product.name}</h5>
                            <p class="card-text">$${product.price}</p>
                            <button class="btn btn-success add-to-cart">Add to Cart</button>

                        </div>
                    </div>
                </div>`;
      productCardsContainer.append(productCard);
    });
  }
  $("#productCards").on("click", ".add-to-cart", function () {
    let productCard = $(this).closest(".card");
    let productName = productCard.find(".card-title").text();
    let productPrice = productCard.find(".card-text").text().replace("$", "");

    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    cart.push({ name: productName, price: productPrice });
    localStorage.setItem("cart", JSON.stringify(cart));

    Swal.fire({
      title: "Added to Cart",
      text: `${productName} has been added to your cart!`,
      icon: "success",
      confirmButtonText: "OK",
    });
  });
});
