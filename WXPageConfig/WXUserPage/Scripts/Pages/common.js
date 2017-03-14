$(function () {
	/*$('#list img').click(function (e) {
		if(parseInt($('#info').css('right'))==0){
			$('#info').animate({right:-200},200).css('display','none');
			$('#frame').animate({left:0},200);
		}else{
			$('#info').animate({right:0},200).css({'display':'block','height':$('#frame').height()});
			$('#frame').animate({left:-200},200);
		}
	});*/
	$(window).manhuatoTop({
		showHeight : 400,//设置滚动高度时显示
		speed : 500 //返回顶部的速度以毫秒为单位
	});
})