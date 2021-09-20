$(document).ready(function () {
  $(".menu-items .menu").on("click", function (e) {
    e.preventDefault()
    $(".mobile-menu").slideToggle();
    if ($(this).find("i").hasClass("fa-bars")) {
      $(this).find("i").removeClass("fa-bars")
      $(this).find("i").addClass("fa-times")
    }
    else {
      $(this).find("i").removeClass(" fa-times")
      $(this).find("i").addClass("fa-bars")
    }

  });


  var attr = $(this).attr("data-filter");
  $(".categorycare").click(function (e) {
    e.preventDefault(e)

    var value = $(this).attr("data-filter");
    if (value == "all") {
      $(".filter").show("1000");
      // $(".filter").parent().show("1000");

    }
    else {
      $(".filter").not("." + value).hide("1000");
      // $(".filter").not("." + value).parent().hide("1000");
      $(".filter").filter("." + value).show("1000");
    }

    $(".categorycare").removeClass("research-active");
    $(this).addClass("research-active")
  })


    //$(document).ready(function () {
    //    $(".menu ul li").click(function (e) {
    //        e.preventDefault(e)
    //        $("ul li ").removeClass(" active-nav");
    //        $(this).addClass(" active-nav")
    //    })

    //})




  //-----------------------------------------Slider----------------------

  //-aboutdaki team
  $('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    responsiveClass:true,
    responsive: {
      // breakpoint from 0 up
      0: {
        items: 1,
        nav: false,
        
      },
      // breakpoint from 480 up
      480: {
        items: 3,
        nav: false,
        
      },
      // breakpoint from 768 up
      768: {
        items: 4,
        nav: false,
        
      },
    }

  })

  //homda testimonial
  $('.one-time').slick({
    infinite: true,
    speed: 300,
    slidesToShow: 1,
    adaptiveHeight: true,
    autoplay: true,
    autoplaySpeed: 1000,
  });





  //homda latestpost,distribute
  $('.multiple-items').slick({
    dots: true,
    infinite: false,
    speed: 300,
    dots: false,
    prevArrow: false,
    nextArrow: false,
    slidesToShow: 3,
    slidesToScroll: 4,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2
        }
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }

    ]
  });


  //main slider button---------
  $('.single-item').slick({
    dots: false,
    prevArrow: false,
    nextArrow: false

  });

  //---------------------------------------------------Son---------


  //---------------------------Nav
  var height = $(".navbar").height();
  $(window).scroll(function () {
    if ($(this).scrollTop() > height) {
      $(".navbar").addClass("position-fixed");
      $(".main .navbar .main-menu .menu ul li a").addClass("scroll-nav");

    }
    else {
      $(".navbar").removeClass("position-fixed");
      $(".main .navbar .main-menu .menu ul li a").removeClass("scroll-nav");
    }
  })


  var loader = document.getElementById("preloader");

  window.addEventListener("load", function () {
    loader.style.display = "none";
  })





  //navin actividi lazim olmadi 
  //  $(".menu ul li").click(function(e){
  //    e.preventDefault(e)
  //   $(".menu ul li").removeClass("active-nav");
  //   $(this).addClass("active-nav")


  //  })



  //service
  // $(".passiv").removeClass("active");
  // $(this).addClass("active")

  //   $('.part-mainslider').flexslider({
  //     directionNav: false,
  //     contolNav: false
  // })

  //other category filtir

  // $(".categorycare").click(function (e) {
  //  var attr=$(this).attr(data-filter);

  //  $(".categorycare").remove("research-active")
  //  $(".categorycare").addClass("research-active")

  //   $(".filter").hide();
  //   if(attr=="cardiology")
  //   {
  //     $("."+attr).show();

  //   }
  //   else if(attr=="pediatric")
  //   {
  //       $("."+attr).show();
  //   }
  //   else if(attr=="anestheslology")
  //   {
  //       $("."+attr).show();
  //   }
  //   else if(attr=="pharmacy")
  //   {
  //       $("."+attr).show();
  //   }
  //   else if(attr=="orthopedics")
  //   {
  //       $("."+attr).show();
  //   }

  // })


  $("#a-appoint").on("click", function (e) {
    e.preventDefault(e);
    $(".addition-appointment").toggle();

  });

  $("#searchTg").on("click", function (e) {
    e.preventDefault(e);
    $(".addition-search").toggle();
    var y = document.getElementById("custom-searchbtn");
    if (y.className === "fas fa-search") {
      y.className = "fas fa-times";
      // console.log("sodj");
    }
    else {
      y.className = "fas fa-search";
      // console.log("sldjsk");
    }

  });



  // $("#a-appoint").on("click", function (e) {
  //   e.preventDefault(e);
  //   console.log("wdjo");
  //    var x = document.getElementById("addition-appointment1")
  //   if (x.className==="addition-appointment") {
  //     x.className += " show";
  //   }
  //   else{
  //     x.className="addition-appointment";
  //   }
  //   // if (x.className==="addition-appointment") {
  //   //   x.style.display="block";
  //   //   x += " show";
  //   // }
  //   // else{
  //   //   x.className="addition-appointment";
  //   //   x.style.display ="none";
  //   // }

  //   // (".addition-appointment").show();


  // //  if(hasClass("addition-appointment"))   {
  // //   $(".addition-appointment").hide();

  // //  }
  // //  else{
  // //   (".addition-appointment").show();
  // //  }                                                                                                       
  // });






  // $(".search").on("click", function (e) {
  //   e.preventDefault()
  //   $(".addition-search").slideToggle();
  //   var y = document.getElementById("mf");
  //   if (y.className=== "fas fa-search") {
  //     y.className-=" fa-search";
  //     y.className +=" fa-times";
  //     console.log("sodj")
  //   }
  //   else {
  //     y.className -=" fa-times";
  //     y.className+=" fa-search";
  //     console.log("sldjsk")
  //   }

  // });



  //faq
  // $(".custom-title").on("click", function (e) {
  //   e.preventDefault()
  //   $(".custom-description").slideToggle();
  //   if ($(this).find("i").hasClass("fa-plus")) {
  //     $(this).find("i").removeClass("fa-plus")
  //     $(this).find("i").addClass("fa-minus")
  //   }
  //   else {
  //     $(this).find("i").addClass("fa-plus")
  //   }

  // });




  //--------- //auto firlanan
  //   $('.slider').slick({
  //     infinite: true,
  //     slidesToShow: 3,
  //     slidesToScroll: 1,
  //     arrows: true,
  //     autoplay: true,
  //     autoplaySpeed: 2000,
  //     responsive: [
  //       {
  //         breakpoint: 1200,
  //         settings: {
  //           slidesToShow: 2,
  //           slidesToScroll: 1
  //         }
  //       },
  //       {
  //         breakpoint: 1008,
  //         settings: {
  //           slidesToShow: 1,
  //           slidesToScroll: 1
  //         }
  //       },
  //       {
  //         breakpoint: 800,
  //         settings: "unslick"
  //       }

  //     ]
  //   });
  //-----------------
  $("#rdetailimg").on("click", function (e) {
    e.preventDefault(e)
    console.log("fewf")
    $(".getVideo").fadeToggle(300).css("display", "flex");
    // $("research-detail").css("display","none")
    // $(".getVideo").addClass("d-flex");
    // console.log("b")
  })
  $(".icon-video ").on("click", function () {
    // $(".getVideo").removeClass("d-flex");
    $(".getVideo").fadeToggle(300);
    // console.log("b")
  });

  $(".additional .mainsl-video").on("click", function (e) {
    e.preventDefault(e)
    console.log("fewf")
    $("#mainSilder .hospitalVideo").fadeToggle(300).css("display", "flex");
    $(".navbar").css("display", "none")
    // $("research-detail").css("display","none")
    // $(".getVideo").addClass("d-flex");
    // console.log("b")
  })
  $(".icon-video ").on("click", function () {
    // $(".getVideo").removeClass("d-flex");
    $(".hospitalVideo").fadeToggle(300);
    $(".navbar").css("display", "block")

    // console.log("b")
  });

  // $(".research-single .up-media #expand").on("click", function (e) {
  //   e.preventDefault(e)
  //   console.log("fewf")

  //   if ($(this).parents("first")){
  //     $(".research-single .first .categoryPicture").fadeToggle(300).css("display", "flex");
  //     $(".navbar").css("display","none")
  //   }
  //   else if ($(this).parents("second")){
  //     $(".research-single .second .categoryPicture").fadeToggle(300).css("display", "flex");
  //     $(".navbar").css("display","none")
  //   }

 

    //------nanan---
    //$(function () {
    //    $('.menu a[href^="/' + location.pathname.split("/")[1] + '"]').addClass('active-nav');
    //});
    //-------------------------------


  // $("research-detail").css("display","none")
  // $(".getVideo").addClass("d-flex");
  // console.log("b")
})
$(".icon-videos ").on("click", function () {
  // $(".getVideo").removeClass("d-flex");
  $(".categoryPicture").fadeToggle(300);
  $(".navbar").css("display", "block")

  // console.log("b")
});



$("#datepi").datetimepicker();


//-------------------slidercomma-----------

//aboutdaki teamde isdifade edilib


$('.mainSlider .owl-carousel').owlCarousel({
  items: 1,
  loop: true,
  margin: 10,
  nav: true,
  infinite: true,
})

//Reseacrh detailda olan slider






//homda latestpost
// $('.multiple-items').slick({
//   infinite: true,
//   slidesToShow: 3,
//   slidesToScroll: 3
// });




// $('.single-item').slick();
//   $('.owl-carousel').owlCarousel({
//     loop:true,
//     margin:10,
//     nav:true,
//     responsive:{
//         0:{
//             items:1
//         },
//         600:{
//             items:1
//         },
//         1000:{
//             items:1
//         }
//     }
// })
//   $('.slider').slick({
//     arrows: true,
//     prevArrow: $('#prev'),
//     nextArrow: $('#next'),
//     dots: true,
// });
// $('.single-item').slick();


// $('.owl-carouselo').owlCarousel({
//   items: 3,
//   loop: true,
//   margin: 10,
//   nav: true,
// })

// $(".arrow-slider .left").on("click", function (e) {
//   e.preventDefault()
//   console.log("asd")
// })




// $( function() {
//   $( "#datepicker" ).datepicker();
// } );







let titles = document.getElementsByClassName("custom-title");
let contents = document.getElementsByClassName("custom-description");

for (let i = 0; i < titles.length; i++) {
  titles[i].addEventListener("click", function (e) {

    //Title
    for (let j = 0; j < titles.length; j++) {
      titles[j].classList.remove("custom-active")

    }

    this.classList.add("custom-active");

    //Content
    for (let j = 0; j < contents.length; j++) {
      contents[j].classList.remove("show")
    }

    this.nextElementSibling.classList.toggle("show");
  })
}

let navItem = document.getElementsByClassName("custom-tab-menu-nav-item");
let contentItem = document.getElementsByClassName("custom-tab-menu-content-item");

for (let i = 0; i < navItem.length; i++) {
  navItem[i].addEventListener("click", function (e) {
    e.preventDefault();

    for (let j = 0; j < navItem.length; j++) {
      navItem[j].classList.remove("active");
    }

    this.classList.add("active");


    for (let j = 0; j < contentItem.length; j++) {
      contentItem[j].classList.remove("show");
    }

    for (let j = 0; j < contentItem.length; j++) {
      if (this.dataset.target == contentItem[j].dataset.target) {
        contentItem[j].classList.add("show");
        return;
      }
    }
  });
}
//--------------------
//let countUp = (countItems) => {
//  for (let j = 0; j < countItems.length; j++) {
//    let i = 0;
//    let step = Number(document.getElementsByClassName("growNum")[j].dataset.step);
//    let speed = Number(document.getElementsByClassName("growNum")[j].dataset.speed);
//    let myNum = Number(document.getElementsByClassName("growNum")[j].dataset.number);

//    let countUp = (number) => {
//      if (i >= number) {
//        clearInterval(myInterval);
//      }
//      i += step;
//      if (i > number) {
//        i = number;
//      }
//      countItems[j].innerHTML = i;

//    }
//    let myInterval = setInterval(function () {
//      countUp(myNum);
//    }, speed);
//  }

//}




let pathName = window.location.pathname;

const resultPath = pathName.split("/");


if (resultPath[resultPath.length - 1] === "teamDetail.html") {
  window.addEventListener("scroll", function (e) {

  })
} else {
  window.addEventListener("scroll", function (e) {

    if (document.documentElement.scrollTop >= 1580) {

      $('.inner').each(function () {
        var $this = $(this);
        var per = $this.attr('per');
        $this.css("width", per + '%');
      })
    }
  })
}


window.addEventListener("scroll", function (e) {
  // console.log(document.documentElement.scrollTop);
  let counterItem = document.querySelectorAll(".growNum");

  if (document.documentElement.scrollTop >= 925) {

    countUp(counterItem);

  }
})

//---------------------------

// function myFunction() {
//   var y= document.getElementsByClassName("appointment").click(){};
//   var x = document.getElementsByClassName("addition-appointment");
//   if (x.style.display === "none") {
//     x.style.display = "block";
//   } else {
//     x.style.display = "none";
//   }
// }


let mybutton = document.getElementById("myBtnScrol");

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}

function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}

