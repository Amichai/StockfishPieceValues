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
            init();
        });

        var init = function() {
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
