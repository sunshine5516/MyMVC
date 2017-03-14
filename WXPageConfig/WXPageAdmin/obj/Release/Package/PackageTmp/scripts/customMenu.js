
			/*function add_zi1(){
				var tr1 = document.getElementById("tab1");
				var s1 = document.getElementsByName("zhicaidan1").length;
				if(s1 <= 4){
					$(tr1).after("<tr name='zhicaidan1'><td><input type='tel' value='11' /></td><td>——子：<input type='text'/></td><td><select onchange='getValue()' id='zhu1'><option value='0'>请选择</option><option value='1'>发送信息</option><option value='2'>跳转图文信息页</option><option value='3'>跳转链接</option></select></td><td><a href='html/wenben.html' id='zhu1_1' style='display: none;'><input type='text' style='border: none;' placeholder='点击编辑文本信息'/></a><a href='edit.html' id='zhu1_2' style='display: none;'><input value='点击编辑图文信息' type='button'/></a><input type='text' id='zhu1_3' style='display: none;' placeholder='请输入链接地址' /></td><td><input type='checkbox' /></td><td><a href='#'>删除</a></td></tr>");
				}else{
					return;
				}
			}
			function add_zi2(){
				var tr2 = document.getElementById("tab2");
				var s2 = document.getElementsByName("zhicaidan2").length;
				if(s2 <= 4){
					$(tr2).after("<tr name='zhicaidan2'><td><input type='tel' value='21' /></td><td>——子：<input type='text'/></td><td><select onchange='getValue1()' id='zhu1'><option value='0'>请选择</option><option value='1'>发送信息</option><option value='2'>跳转图文信息页</option><option value='3'>跳转链接</option></select></td><td><a href='html/wenben.html' id='zhu1_1' style='display: none;'><input type='text' style='border: none;' placeholder='点击编辑文本信息'/></a><a href='edit.html' id='zhu1_2' style='display: none;'><input value='点击编辑图文信息' type='button'/></a><input type='text' id='zhu1_3' style='display: none;' placeholder='请输入链接地址' /></td><td><input type='checkbox' /></td><td><a href='#'>删除</a></td></tr>");
				}
			}
			function add_zi3(){
				var tr3 = document.getElementById("tab3");
				var s3 = document.getElementsByName("zhicaidan3").length;
				if(s3 <= 4){
					$(tr3).after("<tr name='zhicaidan3'><td><input type='tel' value='31' /></td><td>——子：<input type='text'/></td><td><select onchange='getValue1()' id='zhu1'><option value='0'>请选择</option><option value='1'>发送信息</option><option value='2'>跳转图文信息页</option><option value='3'>跳转链接</option></select></td><td><a href='html/wenben.html' id='zhu1_1' style='display: none;'><input type='text' style='border: none;' placeholder='点击编辑文本信息'/></a><a href='edit.html' id='zhu1_2' style='display: none;'><input value='点击编辑图文信息' type='button'/></a><input type='text' id='zhu1_3' style='display: none;' placeholder='请输入链接地址' /></td><td><input type='checkbox' /></td><td><a href='#'>删除</a></td></tr>");
				}
			}*/
	/*		function show_zi1(){
				var i = 0;
				
				if(i=1){
					document.getElementById("z1_zi1").style.display='table-row';
				}
			}
			*/
			window.onload=function(){    
   				onload1();    
   				onload2();    
   				onload3();    
			}  
			function onload1(){
			 	 var a = 0;
			 	 document.getElementById("add1").onclick = function(){
			 	 	a++;
			 	 	if(a == 1){
			 	 		document.getElementById("z1_zi1").style.display='table-row';
			 	 	}
			 	 	if(a == 2){
			 	 		document.getElementById("z1_zi2").style.display='table-row';
			 	 	}
			 	 	if(a == 3){
			 	 		document.getElementById("z1_zi3").style.display='table-row';
			 	 	}
			 	 	if(a == 4){
			 	 		document.getElementById("z1_zi4").style.display='table-row';
			 	 	}
			 	 	if(a == 5){
			 	 		document.getElementById("z1_zi5").style.display='table-row';
			 	 	}
			 	 }
			 }
			function onload2(){
			 	 var b = 0;
			 	 document.getElementById("add2").onclick = function(){
			 	 	b++;
			 	 	if(b == 1){
			 	 		document.getElementById("z2_zi1").style.display='table-row';
			 	 	}
			 	 	if(b == 2){
			 	 		document.getElementById("z2_zi2").style.display='table-row';
			 	 	}
			 	 	if(b == 3){
			 	 		document.getElementById("z2_zi3").style.display='table-row';
			 	 	}
			 	 	if(b == 4){
			 	 		document.getElementById("z2_zi4").style.display='table-row';
			 	 	}
			 	 	if(b == 5){
			 	 		document.getElementById("z2_zi5").style.display='table-row';
			 	 	}
			 	 }
			 }
			function onload3(){
			 	 var c = 0;
			 	 document.getElementById("add3").onclick = function(){
			 	 	c++;
			 	 	if(c == 1){
			 	 		document.getElementById("z3_zi1").style.display='table-row';
			 	 	}
			 	 	if(c == 2){
			 	 		document.getElementById("z3_zi2").style.display='table-row';
			 	 	}
			 	 	if(c == 3){
			 	 		document.getElementById("z3_zi3").style.display='table-row';
			 	 	}
			 	 	if(c == 4){
			 	 		document.getElementById("z3_zi4").style.display='table-row';
			 	 	}
			 	 	if(c == 5){
			 	 		document.getElementById("z3_zi5").style.display='table-row';
			 	 	}
			 	 }
			 }
			function getValue1(){
				var objs = document.getElementById("zhu1");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_1").show();
					$("#zhu1_2").hide();
					$("#zhu1_3").hide();
				}
				if(val==2){
					$("#zhu1_2").show();
					$("#zhu1_1").hide();
					$("#zhu1_3").hide();
				}
				if(val==3){
					$("#zhu1_3").show();
					$("#zhu1_1").hide();
					$("#zhu1_2").hide();
				}
				if(val==0){
					$("#zhu1_1").hide();
					$("#zhu1_2").hide();
					$("#zhu1_3").hide();
				}
			}
			function getValue2(){
				var objs = document.getElementById("zhu2");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_1").show();
					$("#zhu2_2").hide();
					$("#zhu2_3").hide();
				}
				if(val==2){
					$("#zhu2_2").show();
					$("#zhu2_1").hide();
					$("#zhu2_3").hide();
				}
				if(val==3){
					$("#zhu2_3").show();
					$("#zhu2_1").hide();
					$("#zhu2_2").hide();
				}
				if(val==0){
					$("#zhu2_3").hide();
					$("#zhu2_1").hide();
					$("#zhu2_2").hide();
				}
			}
			function getValue3(){
				var objs = document.getElementById("zhu3");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_1").show();
					$("#zhu3_2").hide();
					$("#zhu3_3").hide();
				}
				if(val==2){
					$("#zhu3_2").show();
					$("#zhu3_1").hide();
					$("#zhu3_3").hide();
				}
				if(val==3){
					$("#zhu3_3").show();
					$("#zhu3_1").hide();
					$("#zhu3_2").hide();
				}
				if(val==0){
					$("#zhu3_3").hide();
					$("#zhu3_1").hide();
					$("#zhu3_2").hide();
				}
			}
			function getValue11(){
				var objs = document.getElementById("zhu1_zi1");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_zi1_1").show();
					$("#zhu1_zi1_2").hide();
					$("#zhu1_zi1_3").hide();
				}
				if(val==2){
					$("#zhu1_zi1_2").show();
					$("#zhu1_zi1_1").hide();
					$("#zhu1_zi1_3").hide();
				}
				if(val==3){
					$("#zhu1_zi1_3").show();
					$("#zhu1_zi1_1").hide();
					$("#zhu1_zi1_2").hide();
				}
				if(val==0){
					$("#zhu1_zi1_3").hide();
					$("#zhu1_zi1_1").hide();
					$("#zhu1_zi1_2").hide();
				}
			}
			function getValue12(){
				var objs = document.getElementById("zhu1_zi2");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_zi2_1").show();
					$("#zhu1_zi2_2").hide();
					$("#zhu1_zi2_3").hide();
				}
				if(val==2){
					$("#zhu1_zi2_2").show();
					$("#zhu1_zi2_1").hide();
					$("#zhu1_zi2_3").hide();
				}
				if(val==3){
					$("#zhu1_zi2_3").show();
					$("#zhu1_zi2_1").hide();
					$("#zhu1_zi2_2").hide();
				}
				if(val==0){
					$("#zhu1_zi2_3").hide();
					$("#zhu1_zi2_1").hide();
					$("#zhu1_zi2_2").hide();
				}
			}
			function getValue13(){
				var objs = document.getElementById("zhu1_zi3");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_zi3_1").show();
					$("#zhu1_zi3_2").hide();
					$("#zhu1_zi3_3").hide();
				}
				if(val==2){
					$("#zhu1_zi3_2").show();
					$("#zhu1_zi3_1").hide();
					$("#zhu1_zi3_3").hide();
				}
				if(val==3){
					$("#zhu1_zi3_3").show();
					$("#zhu1_zi3_1").hide();
					$("#zhu1_zi3_2").hide();
				}
				if(val==0){
					$("#zhu1_zi3_3").hide();
					$("#zhu1_zi3_1").hide();
					$("#zhu1_zi3_2").hide();
				}
			}
			function getValue14(){
				var objs = document.getElementById("zhu1_zi4");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_zi4_1").show();
					$("#zhu1_zi4_2").hide();
					$("#zhu1_zi4_3").hide();
				}
				if(val==2){
					$("#zhu1_zi4_2").show();
					$("#zhu1_zi4_1").hide();
					$("#zhu1_zi4_3").hide();
				}
				if(val==3){
					$("#zhu1_zi4_3").show();
					$("#zhu1_zi4_1").hide();
					$("#zhu1_zi4_2").hide();
				}
				if(val==0){
					$("#zhu1_zi4_3").hide();
					$("#zhu1_zi4_1").hide();
					$("#zhu1_zi4_2").hide();
				}
			}
			function getValue15(){
				var objs = document.getElementById("zhu1_zi5");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu1_zi5_1").show();
					$("#zhu1_zi5_2").hide();
					$("#zhu1_zi5_3").hide();
				}
				if(val==2){
					$("#zhu1_zi5_2").show();
					$("#zhu1_zi5_1").hide();
					$("#zhu1_zi5_3").hide();
				}
				if(val==3){
					$("#zhu1_zi5_3").show();
					$("#zhu1_zi5_1").hide();
					$("#zhu1_zi5_2").hide();
				}
				if(val==0){
					$("#zhu1_zi5_3").hide();
					$("#zhu1_zi5_1").hide();
					$("#zhu1_zi5_2").hide();
				}
			}
			function getValue21(){
				var objs = document.getElementById("zhu2_zi1");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_zi1_1").show();
					$("#zhu2_zi1_2").hide();
					$("#zhu2_zi1_3").hide();
				}
				if(val==2){
					$("#zhu2_zi1_2").show();
					$("#zhu2_zi1_1").hide();
					$("#zhu2_zi1_3").hide();
				}
				if(val==3){
					$("#zhu2_zi1_3").show();
					$("#zhu2_zi1_1").hide();
					$("#zhu2_zi1_2").hide();
				}
				if(val==0){
					$("#zhu2_zi1_3").hide();
					$("#zhu2_zi1_1").hide();
					$("#zhu2_zi1_2").hide();
				}
			}
			function getValue22(){
				var objs = document.getElementById("zhu2_zi2");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_zi2_1").show();
					$("#zhu2_zi2_2").hide();
					$("#zhu2_zi2_3").hide();
				}
				if(val==2){
					$("#zhu2_zi2_2").show();
					$("#zhu2_zi2_1").hide();
					$("#zhu2_zi2_3").hide();
				}
				if(val==3){
					$("#zhu2_zi2_3").show();
					$("#zhu2_zi2_1").hide();
					$("#zhu2_zi2_2").hide();
				}
				if(val==0){
					$("#zhu2_zi2_3").hide();
					$("#zhu2_zi2_1").hide();
					$("#zhu2_zi2_2").hide();
				}
			}
			function getValue23(){
				var objs = document.getElementById("zhu2_zi3");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_zi3_1").show();
					$("#zhu2_zi3_2").hide();
					$("#zhu2_zi3_3").hide();
				}
				if(val==2){
					$("#zhu2_zi3_2").show();
					$("#zhu2_zi3_1").hide();
					$("#zhu2_zi3_3").hide();
				}
				if(val==3){
					$("#zhu2_zi3_3").show();
					$("#zhu2_zi3_1").hide();
					$("#zhu2_zi3_2").hide();
				}
				if(val==0){
					$("#zhu2_zi3_3").hide();
					$("#zhu2_zi3_1").hide();
					$("#zhu2_zi3_2").hide();
				}
			}
			function getValue24(){
				var objs = document.getElementById("zhu2_zi4");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_zi4_1").show();
					$("#zhu2_zi4_2").hide();
					$("#zhu2_zi4_3").hide();
				}
				if(val==2){
					$("#zhu2_zi4_2").show();
					$("#zhu2_zi4_1").hide();
					$("#zhu2_zi4_3").hide();
				}
				if(val==3){
					$("#zhu2_zi4_3").show();
					$("#zhu2_zi4_1").hide();
					$("#zhu2_zi4_2").hide();
				}
				if(val==0){
					$("#zhu2_zi4_3").hide();
					$("#zhu2_zi4_1").hide();
					$("#zhu2_zi4_2").hide();
				}
			}
			function getValue25(){
				var objs = document.getElementById("zhu2_zi5");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu2_zi5_1").show();
					$("#zhu2_zi5_2").hide();
					$("#zhu2_zi5_3").hide();
				}
				if(val==2){
					$("#zhu2_zi5_2").show();
					$("#zhu2_zi5_1").hide();
					$("#zhu2_zi5_3").hide();
				}
				if(val==3){
					$("#zhu2_zi5_3").show();
					$("#zhu2_zi5_1").hide();
					$("#zhu2_zi5_2").hide();
				}
				if(val==0){
					$("#zhu2_zi5_3").hide();
					$("#zhu2_zi5_1").hide();
					$("#zhu2_zi5_2").hide();
				}
			}
			function getValue31(){
				var objs = document.getElementById("zhu3_zi1");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_zi1_1").show();
					$("#zhu3_zi1_2").hide();
					$("#zhu3_zi1_3").hide();
				}
				if(val==2){
					$("#zhu3_zi1_2").show();
					$("#zhu3_zi1_1").hide();
					$("#zhu3_zi1_3").hide();
				}
				if(val==3){
					$("#zhu3_zi1_3").show();
					$("#zhu3_zi1_1").hide();
					$("#zhu3_zi1_2").hide();
				}
				if(val==0){
					$("#zhu3_zi1_3").hide();
					$("#zhu3_zi1_1").hide();
					$("#zhu3_zi1_2").hide();
				}
			}
			function getValue32(){
				var objs = document.getElementById("zhu3_zi2");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_zi2_1").show();
					$("#zhu3_zi2_2").hide();
					$("#zhu3_zi2_3").hide();
				}
				if(val==2){
					$("#zhu3_zi2_2").show();
					$("#zhu3_zi2_1").hide();
					$("#zhu3_zi2_3").hide();
				}
				if(val==3){
					$("#zhu3_zi2_3").show();
					$("#zhu3_zi2_1").hide();
					$("#zhu3_zi2_2").hide();
				}
				if(val==0){
					$("#zhu3_zi2_3").hide();
					$("#zhu3_zi2_1").hide();
					$("#zhu3_zi2_2").hide();
				}
			}
			function getValue33(){
				var objs = document.getElementById("zhu3_zi3");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_zi3_1").show();
					$("#zhu3_zi3_2").hide();
					$("#zhu3_zi3_3").hide();
				}
				if(val==2){
					$("#zhu3_zi3_2").show();
					$("#zhu3_zi3_1").hide();
					$("#zhu3_zi3_3").hide();
				}
				if(val==3){
					$("#zhu3_zi3_3").show();
					$("#zhu3_zi3_1").hide();
					$("#zhu3_zi3_2").hide();
				}
				if(val==0){
					$("#zhu3_zi3_3").hide();
					$("#zhu3_zi3_1").hide();
					$("#zhu3_zi3_2").hide();
				}
			}
			function getValue34(){
				var objs = document.getElementById("zhu3_zi4");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_zi4_1").show();
					$("#zhu3_zi4_2").hide();
					$("#zhu3_zi4_3").hide();
				}
				if(val==2){
					$("#zhu3_zi4_2").show();
					$("#zhu3_zi4_1").hide();
					$("#zhu3_zi4_3").hide();
				}
				if(val==3){
					$("#zhu3_zi4_3").show();
					$("#zhu3_zi4_1").hide();
					$("#zhu3_zi4_2").hide();
				}
				if(val==0){
					$("#zhu3_zi4_3").hide();
					$("#zhu3_zi4_1").hide();
					$("#zhu3_zi4_2").hide();
				}
			}
			function getValue35(){
				var objs = document.getElementById("zhu3_zi5");
				var val = objs.options[objs.selectedIndex].value;
				if(val==1){
					$("#zhu3_zi5_1").show();
					$("#zhu3_zi5_2").hide();
					$("#zhu3_zi5_3").hide();
				}
				if(val==2){
					$("#zhu3_zi5_2").show();
					$("#zhu3_zi5_1").hide();
					$("#zhu3_zi5_3").hide();
				}
				if(val==3){
					$("#zhu3_zi5_3").show();
					$("#zhu3_zi5_1").hide();
					$("#zhu3_zi5_2").hide();
				}
				if(val==0){
					$("#zhu3_zi5_3").hide();
					$("#zhu3_zi5_1").hide();
					$("#zhu3_zi5_2").hide();
				}
			}
