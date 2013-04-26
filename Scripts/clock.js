window.requestAnimFrame = (function(){
    return  window.requestAnimationFrame   ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame    ||
        window.oRequestAnimationFrame      ||
        window.msRequestAnimationFrame     ||
        function( callback ){
            window.setTimeout(callback, 1000/60);
        };
})();
//兼容浏览器
window.addEvent=(function(){
		if(document.addEventListener){
			return function(el,type,fn){
				if(el.length){
					for(var i=0;i<el.length;i++){
						addEvent(el[i],type,fn);
					}
					}else{
						el.addEventListener(type,fn,false);
					}
		};
		}else{
			return function(el,type,fn){
		if(el.length){
			for(var i=0;i<el.length;i++){
			addEvent(el[i],type,fn);
			}
		}else{
			el.attachEvent('on'+type,function(){
				return fn.call(el,window.event);
		});
		}
		};
		}
})();

var clock = {
    canvasId:"clock",
    context:undefined,
    width:undefined,
    height:undefined,
    r:undefined,
    focusFactor:0,
    mouseOver:false,

    init:function(){
        var canvas = document.getElementById(this.canvasId);
        this.context = canvas.getContext("2d");
        this.width = canvas.width;
        this.height = canvas.height;
        this.context.translate(this.width/2, this.height/2);
        this.r = 0.45*(this.width>=this.height ? this.height : this.width);
        addEvent(canvas,
            "mouseover",
            function(){
                clock.mouseOver = true;
            }
        );
        addEvent(canvas,
            "mouseout",
            function(){
                clock.mouseOver = false;
            }
        );
    },

    animate:function(){
        if(this.mouseOver == true && this.focusFactor<1){
            this.focusFactor += 0.01;
        }
        if(this.mouseOver == false && this.focusFactor>0){
            this.focusFactor -= 0.04;
        }

        this.draw();
    },

    draw:function(){
        this.drawClock();
    },

    drawClock:function(){
        var context = this.context;
        var r = this.r;
        var now = new Date();
        var hour = now.getHours();
        var minute = now.getMinutes();
        var second = now.getSeconds();
        var millisecond = now.getMilliseconds();

        context.clearRect(-r, -r, 2*r, 2*r);
        context.save();

        var tmpR = Math.ceil(this.focusFactor*255);
        context.fillStyle = "rgb("+tmpR+",0,0)";
        context.rotate(second*Math.PI/30+millisecond*Math.PI/30000);
        context.fillRect(-0.01*r, -0.7*r, 0.02*r, 0.8*r);
        context.restore();

        context.save();
        context.rotate(minute*Math.PI/30+second*Math.PI/(60*30));
        context.fillRect(-0.02*r, -0.6*r, 0.04*r, 0.7*r);
        context.restore();

        context.save();
        context.rotate(hour*Math.PI/6+minute*Math.PI/(60*6));
        context.fillRect(-0.03*r, -0.5*r, 0.06*r, 0.6*r);
        context.restore();

        // Draw Indexes
        context.save();
        for(var i=0; i<=11; i++){
            context.rotate(30*Math.PI/180);
            if(i%3==2){
                context.fillRect(-0.02*r, -0.9*r, 0.04*r, 0.15*r);
            }
            else{
                context.fillRect(-0.01*r, -0.9*r, 0.02*r, 0.1*r);
            }
        }
        context.restore();
        if(this.focusFactor > 0){
            context.save();
            var tmp = Math.ceil((1-this.focusFactor)*255);
            context.fillStyle = "rgb("+tmp+","+tmp+","+tmp+")";
            for(var i=0; i<=59; i++){
                context.rotate(Math.PI/30);
                if(i%5!=4){
                    context.fillRect(-0.01*r, -0.9*r, 0.02*r, 0.04*r);
                }
            }
            context.restore();
        }
    }
};


function init(){
    clock.init();
    animate();
}

function animate(){
    clock.animate();
    requestAnimFrame(animate);
}

window.onload = init;