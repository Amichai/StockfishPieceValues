var app = angular.module('chessApp', []);

app.controller('analysisCtrl', ['$scope', '$http',
    function($scope, $http) {

        $scope.loadGame = function() {
            $http.post(baseUrl + 'api/game/', $scope.pgn)
                .then(function(result) {
                });
        }

        $scope.getClass = function (x, y) {
            var a = x % 2 == 0;
            var b = y % 2 == 0;
            if (a == b) {
                return "light-cell";
            }

            return "dark-cell";
        }

        $scope.getTransform = function (x, y) {
            return "translate(" + x * 64 + "px, " + y * 64 + "px)";
        }

        angular.element(document).ready(function () {
            init3();

            var ticker = $.connection.gameState; // the generated client-side hub proxy

            // Add client-side hub methods that the server will call
            $.extend(ticker.client, {
                updateStockPrice: function (stock) {
                    var displayStock = formatStock(stock),
                        $row = $(rowTemplate.supplant(displayStock)),
                        $li = $(liTemplate.supplant(displayStock)),
                        bg = stock.LastChange < 0
                                ? '255,148,148' // red
                                : '154,240,117'; // green

                    $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
                        .replaceWith($row);
                    $stockTickerUl.find('li[data-symbol=' + stock.Symbol + ']')
                        .replaceWith($li);

                    $row.flash(bg, 1000);
                    $li.flash(bg, 1000);
                },

                marketOpened: function () {
                    $("#open").prop("disabled", true);
                    $("#close").prop("disabled", false);
                    $("#reset").prop("disabled", true);
                    scrollTicker();
                },

                marketClosed: function () {
                    $("#open").prop("disabled", false);
                    $("#close").prop("disabled", true);
                    $("#reset").prop("disabled", false);
                    stopTicker();
                },

                marketReset: function () {
                    return init();
                }
            });

            // Start the connection
            $.connection.hub.start()
                .then(function () {
                    return ticker.server.getMarketState();
                })
                .done(function (state) {

                });
        });

        var init3 = function() {
            $scope.boardState = [
                -4, -2, -3, -5, -6, -3, -2, -4,
                -1, -1, -1, -1, -1, -1, -1, -1,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 1, 1, 1, 1,
                4, 2, 3, 5, 6, 3, 2, 4
            ];

            update();
        };

        // at the bottom of your controller
        var update = function () {
            for (var i = 0; i < $scope.boardState.length; i++) {
                var x = i % 8;
                var y = Math.floor(i / 8);

                var v = $scope.boardState[i];

                var colorPrefix = v < 0 ? 'black' : 'white';
                var target = $('.X' + x + 'Y' + y);
                switch (Math.abs(v)) {
                    case 1:
                        target.addClass(colorPrefix + '-pawn');
                        break;
                    case 2:
                        target.addClass(colorPrefix + '-knight');
                        break;
                    case 3:
                        target.addClass(colorPrefix + '-bishop');
                        break;
                    case 4:
                        target.addClass(colorPrefix + '-rook');
                        break;
                    case 5:
                        target.addClass(colorPrefix + '-queen');
                        break;
                    case 6:
                        target.addClass(colorPrefix + '-king');
                        break;

                default:
                }
            }
        };


    }]);
