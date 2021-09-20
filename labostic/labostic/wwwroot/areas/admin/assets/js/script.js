/*
Author       : Dreamguys
Template Name: EMR - Bootstrap Admin Template
Version      : 1.0
*/

(function ($) {
	"use strict";


	let c = 0;
	let CalcI = () => {
		c = $(".rs").length - 1;
	}
	CalcI();

	let i = 0;

	$('#addWriter').click(function (e) {
		console.log($(this));
		$.ajax({
			url: "GetWriters",
			type: "GET",
			dataType: "JSON",
			success: function (response) {
				console.log(response);
				i++;
				let writerM = $(".writer")
				let divrs = $('<div class="rs"style="box-sizing:content-box !important; display:flex !important; margin-bottom:20px !important; "></div>')
				let label = $(' <label for="WriterToResearch[' + i + '].WriterId" class="col-form-label col-md-2">Category</label>')
				let divWriter = $(' <div class="col-md-10"></div>')
				let select = $(' <select name="WriterToResearch[' + i + '].WriterId"  class="form-control"></select>')
				let defaultOption = $('<option selected="" disabled>Select Writer</option>')
				let deleteButton = $('<span class="deleteWrite" style="font-size:21px; color:red; cursor:pointer;">x</span>');

				select.append(defaultOption)

				for (var j = 0; j < response.length; j++) {
					let option = $('<option value="' + response[j].id + '">' + response[j].fullname + '</option>')
					select.append(option);
				}

				divrs.append(label);
				divWriter.append(select);
				divrs.append(divWriter);
				divrs.append(deleteButton)

				writerM.append(divrs);
				writerM.append(hr);
			},
			error: function () { },
			complete: function () {
				$('.form-control').form - control()
			},
		});
	});
	// Variables declarations

	$(document).on('click', '.deleteWrite', function () {
		$(this).parent().remove();
		CalcI();
	});



	$('#addWriter').click(function (e) {
		$.ajax({
			url: "GetSocials",
			type: "GET",
			dataType: "JSON",
			success: function (response) {
				console.log(response);
				c++;
				let writerM = $(".writer")
				let divrs = $('<div class="rs"style="box-sizing:content-box !important;  margin-bottom:20px !important; "></div>')

				let label = $(' <label for="SocialToDoctor[' + c + '].SocialId" class="col-form-label col-md-2">Social</label>')

				let divWriter = $(' <div class="col-md-10"></div>')

				let select = $(' <select name="SocialToDoctor[' + c + '].SocialId"  class="form-control"></select>')

				let defaultOption = $('<option selected="" disabled>Select Writer</option>')

				let deleteButton = $('<span class="deleteWrite" style="font-size:21px; color:red; cursor:pointer; position:relative; left: 446px; bottom:75px;">x</span>');

				select.append(defaultOption);

				let labellink = $('<label for="SocialToDoctor[' + c + '].SocialId" style=display:flex; ;>Link</label>');
				let divLink = $('<input name="SocialToDoctor['+ c +'].Link" style="margin-top:0px!important; border-radius:4px; padding:11px; height:44px; width:35%;" class="input w-full border mt-2" placeholder="Input text">');
				    
				for (var j = 0; j < response.length; j++) {
					let option = $('<option value="' + response[j].id + '">' + response[j].name + '</option>')
					select.append(option);
				}

				divrs.append(label);
				divWriter.append(select);
				divrs.append(divWriter);

				divrs.append(labellink);
				divrs.append(divLink);


				divrs.append(deleteButton)


				writerM.append(divrs);
				writerM.append(hr);
			},
			error: function () { },
			complete: function () {
				$('.form-control').form - control()

			},
		});
	});
	// Variables declarations



	let b = 0;

	$('#addSkill').click(function (e) {
		console.log($(this));
		$.ajax({
			url: "GetSkils",
			type: "GET",
			dataType: "JSON",
			success: function (response) {
				console.log(response);
				b++;
				let writerM = $(".skill")
				let divrs = $('<div class="sr" style="box-sizing:content-box !important;    margin-bottom:20px !important; "></div>')
				let label = $(' <label for="SocialToDoctor[' + b + '].SocialId" class="col-form-label col-md-2">Skill</label>')
				let divWriter = $(' <div class="col-md-10"></div>')
				let select = $(' <select name="SkillToDoctor[' + b + '].SkillId"  class="form-control"></select>')
				let defaultOption = $('<option selected="" disabled>Select Skill</option>')
				let deleteButton = $('<span class="deleteWrite" style="font-size:21px; color:red; cursor:pointer; position:relative;     left: 446px; bottom:75px;">x</span>');

				select.append(defaultOption);

				let labellink = $('<label for="SkillToDoctor[' + b + '].SkillId" style=display:flex; ;>Percent</label>');
				let divLink = $('<input name="SkillToDoctor['+b+'].Percent" style="margin-top:0px!important; border-radius:4px; padding:11px; height:44px; width:35%;" class="input w-full border mt-2" placeholder="Input text">');

				for (var j = 0; j < response.length; j++) {
					console.log(response);
					let option = $('<option value="' + response[j].id + '">' + response[j].name + '</option>')
					select.append(option);
				}

				divrs.append(label);
				divWriter.append(select);
				divrs.append(divWriter);

				divrs.append(labellink);
				divrs.append(divLink);


				divrs.append(deleteButton)


				writerM.append(divrs);
				writerM.append(hr);
			},
			error: function () { },
			complete: function () {
				$('.form-control').form - control()
			},
		});
	});
	// Variables declarations

	$(document).on('click', '.deleteWrite', function () {
		$(this).parent().remove();
		CalcI();
	});


	var $wrapper = $('.main-wrapper');
	var $pageWrapper = $('.page-wrapper');
	var $slimScrolls = $('.slimscroll');

	// Sidebar

	var Sidemenu = function () {
		this.$menuItem = $('#sidebar-menu a');
	};

	function init() {
		var $this = Sidemenu;
		$('#sidebar-menu a').on('click', function (e) {
			if ($(this).parent().hasClass('submenu')) {
				e.preventDefault();
			}
			if (!$(this).hasClass('subdrop')) {
				$('ul', $(this).parents('ul:first')).slideUp(350);
				$('a', $(this).parents('ul:first')).removeClass('subdrop');
				$(this).next('ul').slideDown(350);
				$(this).parent().find('a.active').next().slideDown(350);
				$(this).addClass('subdrop');
			} else if ($(this).hasClass('subdrop')) {
				$(this).removeClass('subdrop');
				$(this).next('ul').slideUp(350);
				$(this).parent().find('a').next().slideUp(350);
			}
		});
		$('#sidebar-menu ul li.submenu a.active').parents('li:last').children('a:first').addClass('active').trigger('click');
	}

	// Sidebar Initiate
	init();

	// Mobile menu sidebar overlay

	$('body').append('<div class="sidebar-overlay"></div>');
	$(document).on('click', '#mobile_btn', function () {
		$wrapper.toggleClass('slide-nav');
		$('.sidebar-overlay').toggleClass('opened');
		$('body').addClass('menu-opened');
		$('.notifications').removeClass('notifications-open');
		return false;
	});

	$(document).on('click', '#filter_search', function () {
		$('#filter_inputs').slideToggle("slow");
	});

	//Notification
	$(document).on('click', '.notifications-item', function (s) {
		s.preventDefault();
		$('.notifications').addClass('notifications-open');
		$('.sidebar-overlay').toggleClass('opened');
		$('body').addClass('menu-opened');
	});
	$(document).on('click', '.clear-noti', function (s) {
		s.preventDefault();
		$('.notifications').removeClass('notifications-open');
		$(".sidebar-overlay").removeClass("opened");
		$('body').removeClass('menu-opened');
	});

	// Sidebar overlay

	$(".sidebar-overlay").on("click", function () {
		$wrapper.removeClass('slide-nav');
		$(".sidebar-overlay").removeClass("opened");
		$('html').removeClass('menu-opened');
		$('.notifications').removeClass('notifications-open');
	});

	// Page Content Height

	if ($('.page-wrapper').length > 0) {
		var height = $(window).height();
		$(".page-wrapper").css("min-height", height);
	}

	// Page Content Height Resize

	$(window).resize(function () {
		if ($('.page-wrapper').length > 0) {
			var height = $(window).height();
			$(".page-wrapper").css("min-height", height);
		}
	});

	// Select 2

	if ($('.select').length > 0) {
		$('.select').select2({
			minimumResultsForSearch: -1,
			width: '100%'
		});
	}

	// Datetimepicker

	if ($('.datetimepicker').length > 0) {
		$('.datetimepicker').datetimepicker({
			format: 'DD/MM/YYYY',
			icons: {
				up: "fa fa-angle-up",
				down: "fa fa-angle-down",
				next: 'fa fa-angle-right',
				previous: 'fa fa-angle-left'
			}
		});
		$('.datetimepicker').on('dp.show', function () {
			$(this).closest('.table-responsive').removeClass('table-responsive').addClass('temp');
		}).on('dp.hide', function () {
			$(this).closest('.temp').addClass('table-responsive').removeClass('temp')
		});
	}

	// Tooltip

	if ($('[data-toggle="tooltip"]').length > 0) {
		$('[data-toggle="tooltip"]').tooltip();
	}

	// Datatable

	if ($('.datatable').length > 0) {
		$('.datatable').DataTable({
			"bFilter": false,
		});
	}

	// Check all email

	$(document).on('click', '#check_all', function () {
		$('.checkmail').click();
		return false;
	});
	if ($('.checkmail').length > 0) {
		$('.checkmail').each(function () {
			$(this).on('click', function () {
				if ($(this).closest('tr').hasClass('checked')) {
					$(this).closest('tr').removeClass('checked');
				} else {
					$(this).closest('tr').addClass('checked');
				}
			});
		});
	}

	// Mail important

	$(document).on('click', '.mail-important', function () {
		$(this).find('i.fa').toggleClass('fa-star').toggleClass('fa-star-o');
	});

	// Summernote

	if ($('.summernote').length > 0) {
		$('.summernote').summernote({
			height: 200,                 // set editor height
			minHeight: null,             // set minimum height of editor
			maxHeight: null,             // set maximum height of editor
			focus: false                 // set focus to editable area after initializing summernote
		});
	}

	// Product thumb images

	if ($('.proimage-thumb li a').length > 0) {
		var full_image = $(this).attr("href");
		$(".proimage-thumb li a").click(function () {
			full_image = $(this).attr("href");
			$(".pro-image img").attr("src", full_image);
			$(".pro-image img").parent().attr("href", full_image);
			return false;
		});
	}

	// Lightgallery

	if ($('#pro_popup').length > 0) {
		$('#pro_popup').lightGallery({
			thumbnail: true,
			selector: 'a'
		});
	}

	// Sidebar Slimscroll

	if ($slimScrolls.length > 0) {
		$slimScrolls.slimScroll({
			height: 'auto',
			width: '100%',
			position: 'right',
			size: '7px',
			color: '#ccc',
			allowPageScroll: false,
			wheelStep: 10,
			touchScrollStep: 100
		});
		var wHeight = $(window).height() - 60;
		$slimScrolls.height(wHeight);
		$('.sidebar .slimScrollDiv').height(wHeight);
		$(window).resize(function () {
			var rHeight = $(window).height() - 60;
			$slimScrolls.height(rHeight);
			$('.sidebar .slimScrollDiv').height(rHeight);
		});
	}

	if ($('.chat-scroll').length > 0) {
		$('.chat-scroll').slimScroll({
			height: 'auto',
			width: '100%',
			position: 'right',
			size: '7px',
			color: '#ccc',
			allowPageScroll: false,
			wheelStep: 10,
			touchScrollStep: 100
		});
	}

	// Small Sidebar

	$(document).on('click', '#toggle_btn', function () {
		if ($('body').hasClass('mini-sidebar')) {
			$('body').removeClass('mini-sidebar');
			$('.subdrop + ul').slideDown();
		} else {
			$('body').addClass('mini-sidebar');
			$('.subdrop + ul').slideUp();
		}
		return false;
	});
	$(document).on('mouseover', function (e) {
		e.stopPropagation();
		if ($('body').hasClass('mini-sidebar') && $('#toggle_btn').is(':visible')) {
			var targ = $(e.target).closest('.sidebar').length;
			if (targ) {
				$('body').addClass('expand-menu');
				$('.subdrop + ul').slideDown();
			} else {
				$('body').removeClass('expand-menu');
				$('.subdrop + ul').slideUp();
			}
			return false;
		}
	});

	// Chat

	var chatAppTarget = $('.chat-window');
	(function () {
		if ($(window).width() > 991)
			chatAppTarget.removeClass('chat-slide');

		$(document).on("click", ".chat-window .chat-users-list a.media", function () {
			if ($(window).width() <= 991) {
				chatAppTarget.addClass('chat-slide');
			}
			return false;
		});
		$(document).on("click", "#back_user_list", function () {
			if ($(window).width() <= 991) {
				chatAppTarget.removeClass('chat-slide');
			}
			return false;
		});
	})();

	CKEDITOR.replace('BiographyDesc');

	$('#cb1').click(function (e) {
		e.preventDefault(e);
		console.log(this)
	})


})(jQuery);