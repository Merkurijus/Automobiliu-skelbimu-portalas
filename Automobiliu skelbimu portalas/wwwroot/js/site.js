// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
   
$(document).ready(function () {
	$('.collapse.in').each(function () {
		$(this).parent().find(".fa").removeClass("fa-plus").addClass("fa-minus");
	});

	$('.collapse').on('shown.bs.collapse', function () {
		$(this).parent().find(".fa-plus").removeClass("fa-plus").addClass("fa-minus");
	}).on('hidden.bs.collapse', function () {
		$(this).parent().find(".fa-minus").removeClass("fa-minus").addClass("fa-plus");
	});
});