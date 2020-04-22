$(document).ready(function(){

  var myPlaylist = new jPlayerPlaylist({
    jPlayer: "#jplayer_N",
    cssSelectorAncestor: "#jp_container_N"
  }, [
        {
            title: "RockStar",
            artist: "Post Malone ft. 21 Savage",
            mp3: "https://localhost:5001/music/RockStar-Post-malone-Ft-21-savage.mp3",
            poster: "images/m0.jpg"
        },
        {
          title:"Lover's Rock",
          artist:"Sade Adu",
          mp3: "https://localhost:5001/music/01%20By%20Your%20Side.m4a",
          poster: "images/m0.jpg"
        },
        {
          title:"Hurt Feelings",
          artist:"Mac Miller",
          mp3: "https://localhost:5001/music/02.%20Hurt%20Feelings.mp3",
          poster: "images/m0.jpg"
        },
        {
          title:"Suffer Head",
          artist:"Mr. Eazi",
          mp3: "https://localhost:5001/music/04.%20Mr%20Eazi,%202baba%20-%20Suffer%20Head.mp3",
          poster: "images/m0.jpg"
        }
    ], {
            playlistOptions: {
              enableRemoveControls: true,
              autoPlay: true
            },
            swfPath: "js/jPlayer",
            supplied: "webmv, ogv, m4v, oga, mp3",
            smoothPlayBar: true,
            keyEnabled: true,
            audioFullScreen: false
        });
  
  $(document).on($.jPlayer.event.pause, myPlaylist.cssSelector.jPlayer,  function(){
    $('.musicbar').removeClass('animate');
    $('.jp-play-me').removeClass('active');
    $('.jp-play-me').parent('li').removeClass('active');
  });

  $(document).on($.jPlayer.event.play, myPlaylist.cssSelector.jPlayer,  function(){
    $('.musicbar').addClass('animate');
  });

  $(document).on('click', '.jp-play-me', function(e){
    e && e.preventDefault();
    var $this = $(e.target);
    if (!$this.is('a')) $this = $this.closest('a');

    $('.jp-play-me').not($this).removeClass('active');
    $('.jp-play-me').parent('li').not($this.parent('li')).removeClass('active');

    $this.toggleClass('active');
    $this.parent('li').toggleClass('active');
    if( !$this.hasClass('active') ){
      myPlaylist.pause();
    }else{
      var i = Math.floor(Math.random() * (1 + 7 - 1));
      myPlaylist.play(i);
    }
    
  });



  // video

  $("#jplayer_1").jPlayer({
    ready: function () {
      $(this).jPlayer("setMedia", {
        title: "Big Buck Bunny",
        m4v: "http://flatfull.com/themes/assets/video/big_buck_bunny_trailer.m4v",
        ogv: "http://flatfull.com/themes/assets/video/big_buck_bunny_trailer.ogv",
        webmv: "http://flatfull.com/themes/assets/video/big_buck_bunny_trailer.webm",
        poster: "images/m41.jpg"
      });
    },
    swfPath: "js",
    supplied: "webmv, ogv, m4v",
    size: {
      width: "100%",
      height: "auto",
      cssClass: "jp-video-360p"
    },
    globalVolume: true,
    smoothPlayBar: true,
    keyEnabled: true
  });

});