

window.addEventListener('load', (event) => {


    getProducts();
    getCategories();
    document.getElementById('ItemsCountText').innerText = (JSON.parse(sessionStorage.getItem('cart')).length);
    
});

function getProducts() {
        fetch("api/Product/")
        .then((response) => {
              if (response.ok && response.status == 200)
                return response.json()

            else {
                alert("something whent wrong ");
             
                return "erro";
            }
        })
        .then(data => {
                    // console.log(data);
   
            if (data != "erro") {

                drow(data);
                      }

        }).catch((error) => {  console.log(error); alert(error) });
 

}
function getCategories() {
    fetch("api/Categories/")
        .then((response) => {

            if (response.ok && response.status == 200)
                return response.json()
            else {
                alert("something whent wrong with the response ");

                return "erro";
            }
        })

            .then(data => {
                console.log(data+"CATEGORIES");

                if (data != "erro") {

                    data.forEach((c) => {
                        var elemnt = document.getElementById("temp-category");
                     
                        var cln = elemnt.content.cloneNode(true);

                        cln.querySelector(".OptionName").innerText = c.name;


                        cln.querySelector('.opt').addEventListener("click", () => {
                            removePoductList();
                            if (document.querySelector('.opt').checked) {
                                getByCategorie(c.categoresId)
                            }
                            else 
                                window.location.href="products.html";
                           // debugger;
                           // reDrowByCategory(c);
                        });
                        document.getElementById("filters").appendChild(cln);
                        // document.body.appendChild(cln);
                    })
                }
            })
        .catch((error) => { debugger; console.log(error); alert(error) });;
}



function reDrowByCategory(c) {
    var arr = [];
   
    console.log(document.querySelector('.opt').checked);
    if (document.querySelector('.opt').checked) {//אם צריך להציג את הקטגוריה
        arr.push(c);//נוסי.ף למערך
        sessionStorage.setItem('myCategory', JSON.stringify(arr));//נדרוס את המערך הקודם ונשמור מחדש 
    }
    else {
        arr.remove(c);//אם לא צריך לבדוק אם היה קיים במערך ולמחוק אותו אם כן
        sessionStorage.setItem('myCategory', JSON.stringify(arr));//שמירת המערך המעודכן
    }
     var categotyTrue=[]
    categotyTrue = JSON.parse(sessionStorage.getItem('myCategory'));
    if (categotyTrue == null) {//אם אף אחד לא שמור שירנדר מחדש את הדף
        window.location.href = "products.html";
    }
    else {
        categotyTrue.forEach((TC) => {//עבור כל אחד שנמצא שיביא את הנתונים.
            getByCategorie(TC.categoresId)
        })
    }
        
    }


 ////remove exsisting PoductList.
        //var a = sessionStorage.getItem('myCategory')

        //    sessionStorage.setItem('myCategory', JSON.stringify(arr));

        //var categotyTrue = JSON.parse(sessionStorage.getItem('myCategory'));
        //console.log(categotyTrue);
        //categotyTrue.forEach((trueCategorie) => {
        //    getByCategorie(trueCategorie.categoresId)
        // })//

function addToShoppingCart(product) {
    var cart = [];
    if (JSON.parse(sessionStorage.getItem('cart')) != null)
        cart = JSON.parse(sessionStorage.getItem('cart'));

    let item = {
        "product":product,
        "quntity":1,
    }
    var flag = false;
   // cart.forEach((e) => e.product.id == product.id)
    if (cart.length > 0) {
        for (let i = 0; i < cart.length; i++) {
            if (cart[i].product.prodId == product.prodId) {
                cart[i].quntity++;
                flag = true;
        }
    }}

    if (flag == false) {
        cart.push(item);
    }
    
        sessionStorage.setItem('cart', JSON.stringify(cart));
        document.getElementById('ItemsCountText').innerText = (JSON.parse(sessionStorage.getItem('cart')).length);
        console.log(parseInt(JSON.parse(sessionStorage.getItem('cart')).length));
    
}
/*}*/
function getByCategorie(id) {
   
    fetch("api/product/" + id).then((response) => {

        if (response.ok && response.status == 200)
            return response.json();
    else {
            alert("something whent wrong ");
                        return "erro";
        }
    })
        .then(data => {
            console.log(data);

            if (data != "erro") {
              
                drow(data);
            }

        }).catch((error) => { debugger; console.log(error); alert(error) });
}

function drow(data) {
    document.getElementById('counter').innerText = data.length;
    data.forEach((d) => {

        var elemnt = document.getElementById("temp-card");

        var cln = elemnt.content.cloneNode(true);
     
        cln.querySelector("img").src = "./images/" + d.image + ".png";

        cln.querySelector(".price").innerText = d.price+"₪" ;
        cln.querySelector(".description").innerText = d.description;
       
        cln.querySelector('button').addEventListener("click", () => { addToShoppingCart(d)} );

        document.getElementById("PoductList").appendChild(cln);
    })
}
function removePoductList() {
    //אלו 2 אופציות לאותו דבר....
    document.getElementById("PoductList").innerHTML = "";
    //document.body.removeChild(document.getElementById("PoductList"));
    //var list = document.createElement('div');
    //list.setAttribute("id", "PoductList");
    //document.body.appendChild(list);
}