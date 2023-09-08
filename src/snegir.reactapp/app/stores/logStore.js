import { EventEmitter } from 'events';
import Dispatcher from '../dispatcher';
import ActionTypes from '../constants';

const CHANGE = 'CHANGE';

class LogStore extends EventEmitter {

    constructor() {
        super();

        this._lastError = null;

        Dispatcher.register(this._registerToActions.bind(this));
    }

    _registerToActions(action) {
        switch (action.actionType) {
            case ActionTypes.LOG_ERROR:
                this._lastError = action.payload;
                this.emit(CHANGE);
                break;

            case ActionTypes.LOG_CLEAR_ERRORS:
                this._lastError = null;
                this.emit(CHANGE);
                break;
        }
    }

    getLastError() {
        return this._lastError;
    }

    addChangeListener(callback) {
        this.on(CHANGE, callback);
    }

    removeChangeListener(callback) {
        this.removeListener(CHANGE, callback);
    }
}

export default new LogStore();