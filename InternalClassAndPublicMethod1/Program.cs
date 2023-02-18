using InternalClassAndPublicMethod2;

var canNotAccessInternalMethod = new PublicClassWithInternalMethod();

/**
 * Consider the following:
 * public - public
 * public - private
 * public - internal
 * public - protected
 * 
 * Only public - public can be accessed from other projects.
 */