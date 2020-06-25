var t = 500;
var max = 5;

function rejectDelay(reason) {
	return new Promise(function(resolve, reject) {
		setTimeout(reject.bind(null, reason), t); 
	});
}

var p = Promise.reject();
for(var i=0; i<max; i++) {
	p = p.catch(attempt).catch(rejectDelay);
}
p = p.then(processResult).catch(errorHandler);


function attempt() {
	var rand = Math.random();
	if(rand < 0.8) {
		throw rand;
	} else {
		return rand;
	}
}
function processResult(res) {
	console.log(res);
}
function errorHandler(err) {
	console.error(err);
}