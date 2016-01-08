var myApp = angular.module('myApp', []);

myApp.controller('GestionEmploiCtrl', function ($scope, $http) {
    $scope.listerTravailleurs = function () {
        $http.get('/api/Travailleurs')
         .success(function (resultat) {
             $scope.travailleurs = resultat;
         })
         .error(function (data) {
             console.log(data);
         });
    }
    $scope.listerTravailleurs();

    $scope.listerEmplois = function () {
        $http.get('/api/Emplois')
         .success(function (result) {
             $scope.emplois = result;
         })
         .error(function (data) {
             console.log(data);
         });
    }
    $scope.listerEmplois();

    $scope.idEmploi = null;
    $scope.dateEntree = null;
    $scope.dateSortie = null;
    $scope.numDossier = null;
    $scope.ajouterEmploi = function () {
        $http.post('/api/Emplois/', {
            idEmploi: $scope.idEmploi,
            dateEntree: $scope.dateEntree,
            dateSortie: $scope.dateSortie,
            numDossier: $scope.numDossier
        })
             .success(function (resultat) {
                 $scope.listerEmplois();

                 $scope.idEmploi = null;
                 $scope.dateEntree = null;
                 $scope.dateSortie = null;
                 $scope.numDossier = null;
             })
             .error(function (data) {
                 console.log(data);
             });
    }

    $scope.supprimerEmploi = function (idEmploi) {
        $http.delete('/api/Emplois/' + idEmploi, { id: idEmploi })
             .success(function (resultat) {
                 $scope.listerEmplois();
             })
             .error(function (data) {
                 console.log(data);
             });
    }
});