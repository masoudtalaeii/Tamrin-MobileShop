//////////////////////////////// Quiantity Input
function quantityDecrement(e) {
  const btn = e.target.parentNode.parentElement.querySelector(
    'button[data-action="increment"]'
  );
  const target = btn.nextElementSibling;
  let value = Number(target.value);
  if (value == 1) return;
  value--;
  target.value = value;
}

function quantityIncrement(e) {
  const btn = e.target.parentNode.parentElement.querySelector(
    'button[data-action="increment"]'
  );
  const target = btn.nextElementSibling;
  let value = Number(target.value);
  value++;
  target.value = value;
}

const quantityDecrementButtons = document.querySelectorAll(
  `button[data-action="decrement"]`
);

const quantityIncrementButtons = document.querySelectorAll(
  `button[data-action="increment"]`
);

quantityDecrementButtons.forEach((btn) => {
  btn.addEventListener("click", quantityDecrement);
});

quantityIncrementButtons.forEach((btn) => {
  btn.addEventListener("click", quantityIncrement);
});
//////////////////////////////////// seacrh bar show and hide
function searchBTN() {
  let searchBar = document.getElementById("searchBar");
  searchBar.classList.toggle("top-20");
  searchBar.classList.toggle("flex");
  searchBar.classList.toggle("hidden");
}
//////////////////////////////////// show Navbar
function showNavbar() {
  let navbar = document.getElementById("navbar");
  navbar.classList.toggle("-right-full");
  navbar.classList.toggle("-right-2");
}
function bgNavbar() {
  let navbar = document.getElementById("navbar");
  navbar.classList.toggle("-right-full");
  navbar.classList.toggle("-right-2");
}
/////////////////////////////////// btn footer go to up
let mybutton = document.getElementById("btn-back-to-top");

mybutton.addEventListener("click", backToTop);

function backToTop() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}
/////////////////////////////////// off sldier timer
// const countDownClock = (number = 100, format = "seconds") => {
//   const d = document;
//   const daysElement = d.querySelector(".days");
//   const hoursElement = d.querySelector(".hours");
//   const minutesElement = d.querySelector(".minutes");
//   const secondsElement = d.querySelector(".seconds");
//   let countdown;
//   convertFormat(format);

//   function convertFormat(format) {
//     switch (format) {
//       case "seconds":
//         return timer(number);
//       case "minutes":
//         return timer(number * 60);
//       case "hours":
//         return timer(number * 60 * 60);
//       case "days":
//         return timer(number * 60 * 60 * 24);
//     }
//   }

//   function timer(seconds) {
//     const now = Date.now();
//     const then = now + seconds * 1000;

//     countdown = setInterval(() => {
//       const secondsLeft = Math.round((then - Date.now()) / 1000);

//       if (secondsLeft <= 0) {
//         clearInterval(countdown);
//         return;
//       }

//       displayTimeLeft(secondsLeft);
//     }, 1000);
//   }

//   function displayTimeLeft(seconds) {
//     daysElement.textContent = Math.floor(seconds / 86400);
//     hoursElement.textContent = Math.floor((seconds % 86400) / 3600);
//     minutesElement.textContent = Math.floor(((seconds % 86400) % 3600) / 60);
//     secondsElement.textContent =
//       seconds % 60 < 10 ? `0${seconds % 60}` : seconds % 60;
//   }
// };

// var countDownDate = new Date("Apr 16, 2024 15:37:25").getTime();
// var now = new Date().getTime();
// var distance = countDownDate - now;
// console.log(distance);

// var daysss = Math.floor(distance / (1000 * 60 * 60 * 24));
// var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
// var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
// var seconds = Math.floor((distance % (1000 * 60)) / 1000);
// console.log(daysss);

// countDownClock(daysss,"days");

(function () {
  const second = 1000,
    minute = second * 60,
    hour = minute * 60,
    day = hour * 24;

  //I'm adding this section so I don't have to keep updating this pen every year :-)
  //remove this if you don't need it
  let today = new Date(),
    yyyy = today.getFullYear(),
    dayMonth = "07/16/",
    birthday = dayMonth + yyyy;

  const countDown = new Date(birthday).getTime(),
    x = setInterval(function () {
      const now = new Date().getTime(),
        distance = countDown - now;
      // (document.getElementById("days").innerText = Math.floor(distance / day)),
      for (let i = 0; i < document.querySelectorAll("#days").length; i++) {
        document.querySelectorAll("#days")[i].innerText = Math.floor(
          distance / day
        );
        document.querySelectorAll("#hours")[i].innerText = Math.floor(
          (distance % day) / hour
        );
        document.querySelectorAll("#minutes")[i].innerText = Math.floor(
          (distance % hour) / minute
        );
        document.querySelectorAll("#seconds")[i].innerText = Math.floor(
          (distance % minute) / second
        );
      }
    }, 1000);
})();
/////////////////////////////////////////// product comparision show select product
function showSelectProduct() {
  let showSelectP = document.getElementById("showSelectP");
  showSelectP.classList.remove("hidden");
}
function closeSelectP() {
  let showSelectP = document.getElementById("showSelectP");
  showSelectP.classList.add("hidden");
}
/////////////////////////////////////////// product images modal
function showImagesProduct() {
  let showImagesP = document.getElementById("showImagesModal");
  showImagesP.classList.remove("hidden");
}
function closeImagesProduct() {
  let showImagesP = document.getElementById("showImagesModal");
  showImagesP.classList.add("hidden");
}
/////////////////////////////////////////// slide show single product
let slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides((slideIndex += n));
}

function currentSlide(n) {
  showSlides((slideIndex = n));
}

function showSlides(n) {
  let i;
  let slides = document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {
    slideIndex = 1;
  }
  if (n < 1) {
    slideIndex = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}
/////////////////////////////////////////////// profile edit address modal
function showEditAddress() {
  let showEditAddress = document.getElementById("showEditAddress");
  showEditAddress.classList.remove("hidden");
}
function closeEditAddress() {
  let showEditAddress = document.getElementById("showEditAddress");
  showEditAddress.classList.add("hidden");
}
