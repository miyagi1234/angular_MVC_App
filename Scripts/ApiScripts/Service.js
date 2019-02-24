app.service("APIService", function ($http) {
    this.getSubs = function (sudID) {
        var url = 'api/Subscriber';
        return $http.get(url).then(function (response) {
            console.log(response.data);
            return response.data;
        });
    }
    this.saveSubscriber = function (sub) {
        return $http({
            method: 'post',
            data: sub,
            url: 'api/Subscriber'
        });
    }
    this.updateSubscriber = function (sub) {
        return $http({
            method: 'put',
            data: sub,
            url: 'api/Subscriber'
        });
    }
    this.deleteSubscriber = function (subID) {
        var url = 'api/Subscriber/' + subID;
        return $http({
            method: 'delete',
            data: subID,
            url: url
        });
    }
});