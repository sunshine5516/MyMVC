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
		showHeight : 400,//���ù����߶�ʱ��ʾ
		speed : 500 //���ض������ٶ��Ժ���Ϊ��λ
	});
})