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

        $scope.pieceEvals = [];

        $scope.getPieceEval = function (x, y) {
            if (!$scope.pieceEvals) {
                return "";
            }

            //return $scope.pieceEvals[y * 8 + x];

            return $scope.pieceEvals[((7 - y) * 8 + x)];
        };

        angular.element(document).ready(function () {
            var gameState = $.connection.gameState; // the generated client-side hub proxy

            // Start the connection
            $.connection.hub.start()
                .then(function () {
                    getCurrentPosition();
                });

            function updateBoard(result) {
                var newBoardState = [];
                for (var i = 0; i < result.length; i++) {
                    var val = result[i];

                    if (val === '/') {
                        continue;
                    }

                    if (val == ' ') {
                        break;
                    }

                    if (!isNaN(parseInt(val))) {
                        for (var j = 0; j < parseInt(val); j++) {
                            newBoardState.push(0);
                        }

                        continue;
                    }

                    switch (val) {
                        case "r":
                            newBoardState.push(-4);
                            break;
                        case "R":
                            newBoardState.push(4);
                            break;

                        case "n":
                            newBoardState.push(-2);
                            break;
                        case "N":
                            newBoardState.push(2);
                            break;

                        case "b":
                            newBoardState.push(-3);
                            break;
                        case "B":
                            newBoardState.push(3);
                            break;

                        case "q":
                            newBoardState.push(-5);
                            break;
                        case "Q":
                            newBoardState.push(5);
                            break;

                        case "k":
                            newBoardState.push(-6);
                            break;
                        case "K":
                            newBoardState.push(6);
                            break;

                        case "p":
                            newBoardState.push(-1);
                            break;
                        case "P":
                            newBoardState.push(1);
                            break;
                        default:
                    }
                }

                $scope.boardState = newBoardState;
                update();

                $scope.$apply();

                gameState.server.getLastMove($.connection.hub.id)
                    .then(function(result) {
                        console.log(result);
                    });
            };

            function getCurrentPosition () {
                gameState.server.getPosition($.connection.hub.id)
                    .then(function(result) {
                        updateBoard(result);
                    });
            };

            $scope.moveList = [];

            $scope.errorStyle = {};

            $scope.submitMove = function () {
                gameState.server.move($scope.move, $.connection.hub.id).then(function (result) {
                    if (result == "") {
                        console.log("invalid move: " + $scope.move);
                        $scope.errorStyle = { 'background-color': 'lightpink' };
                        $scope.$apply();
                    } else {
                        $scope.moveList.push($scope.move);

                        $scope.errorStyle = {};
                        $scope.$apply();

                        gameState.server.getComputerMove($.connection.hub.id)
                            .then(function (result) {
                                updateBoard(result);
                            }).then(function() {
                                gameState.server.getLastMove($.connection.hub.id)
                                    .then(function (result) {
                                        $scope.moveList.push(result);
                                        $scope.$apply();
                                    });
                            }).then(function () {
                                $scope.eval = "--";
                                $scope.$apply();

                                for (var i = 0; i < 64; i++) {
                                    $scope.pieceEvals[i] = 0;
                                }

                                gameState.server.getEval($.connection.hub.id)
                                    .then(function (result) {
                                        $scope.eval = result;
                                        $scope.$apply();
                                    });
                            }).then(function() {
                                gameState.server.getPieceEvals($.connection.hub.id).then(function (evals) {
                                    $scope.pieceEvals = evals;

                                    $scope.$apply();
                                });
                            });

                        updateBoard(result);
                    }
                });
            }

            $scope.restart = function () {
                $scope.moveList = [];
                gameState.server.reset($.connection.hub.id)
                    .then(function () {
                        getCurrentPosition();
                    });
            }
        });

        // at the bottom of your controller
        var update = function () {
            for (var i = 0; i < $scope.boardState.length; i++) {
                var x = i % 8;
                var y = Math.floor(i / 8);

                var v = $scope.boardState[i];

                var colorPrefix = v < 0 ? 'black' : 'white';
                var target = $('.X' + x + 'Y' + y);

                target.removeClass(function (index, classNames) {
                    var current_classes = classNames.split(" "), // change the list into an array
                    classes_to_remove = []; // array of classes which are to be removed

                    $.each(current_classes, function (index, class_name) {
                        // if the classname begins with bg add it to the classes_to_remove array
                        if (class_name.includes("white") || class_name.includes("black")) {
                            classes_to_remove.push(class_name);
                        }
                    });
                    // turn the array back into a string
                    return classes_to_remove.join(" ");
                });

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

            $scope.$apply();
        };
    }]);
