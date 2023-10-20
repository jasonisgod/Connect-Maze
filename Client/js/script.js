
const URL_BASE = 'https://skhhiays.xyz/maze/api/click'
// const URL_BASE = 'https://jasonisgod.xyz/maze/api/click'
// const URL_BASE = 'http://192.168.101.125:8000/click'

var id = 0

function onloadRun() {
    try {
        id = (new URLSearchParams(window.location.search)).get('id')
        var img = document.getElementById('id-img')
        img.src = 'img/maze-logo-' + id + '.png'
        document.getElementById('id-text').textContent = '#' + id
    } catch {
        document.getElementById('id-text').textContent = 'error'
    }
    
}

function onclickBtn(key) {
    fetch(URL_BASE + '?id=' + id + '&key=' + key);
}
