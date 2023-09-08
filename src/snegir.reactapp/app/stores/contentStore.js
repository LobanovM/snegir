import { EventEmitter } from 'events';
import Dispatcher from '../dispatcher';
import ActionTypes from '../constants';

const CHANGE = 'CHANGE';
const CHANGE_FIRST_UNRATED = 'CHANGE_FIRST_UNRATED';

class ContentStore extends EventEmitter {

    constructor() {
        super();

        this.firstUnratedContent = null;

        Dispatcher.register(this._registerToActions.bind(this));
    }

    _registerToActions(action) {
        switch (action.actionType) {
            case ActionTypes.UPDATE_CONTENT_RATING:
                this._updateContentRating(action.payload);
                break;

            case ActionTypes.LOAD_FIRST_UNRATED:
                this._loadFirstUnrated(action.payload);
                break;
        }
    }

    _updateContentRating(content) {
        // local changing of content
        this.emit(CHANGE);
    }

    _loadFirstUnrated(content) {
        this.firstUnratedContent = content;
        this.emit(CHANGE_FIRST_UNRATED);
    }

    getFirstUnrated() {
        return this.firstUnratedContent;
    }

    addChangeListener(callback) {
        this.on(CHANGE, callback);
    }

    removeChangeListener(callback) {
        this.removeListener(CHANGE, callback);
    }

    addChangeFirstUnratedListener(callback) {
        this.on(CHANGE_FIRST_UNRATED, callback);
    }

    removeChangeFirstUnratedListener(callback) {
        this.removeListener(CHANGE_FIRST_UNRATED, callback);
    }
}

export default new ContentStore();