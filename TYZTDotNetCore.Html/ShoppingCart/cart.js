$(document).ready(function() {
    function loadCart() {
        let cart = JSON.parse(localStorage.getItem('cart')) || [];
        let cartItems = $('#cartItems');
        cartItems.empty();
        cart.forEach(item => {
            let cartItem = `
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">${item.name}</h5>
                        <p class="card-text">Price: ${item.price}</p>
                    </div>
                </div>`;
            cartItems.append(cartItem);
        });
    }

    loadCart();
});
